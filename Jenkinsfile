pipeline {

    agent {

        docker { 
    
            image 'mydotnet_sdk:v0'
            args '--network jenkins"'

        }
    }

    stages {

        stage('Restore') {
            steps {

                sh 'dotnet restore'

            }
        }
         
        stage('Build') {
            steps {

                sh 'dotnet sonarscanner begin /k:"MediaTagger" /d:sonar.host.url="http://sonarqube:9000" /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

                sh 'dotnet build --no-restore'
            
                sh 'dotnet sonarscanner end /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

            }
        }

        stage('Deploy') {
            steps {
                
                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --runtime linux-musl-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'
                sh 'docker cp jenkinsagent03:/home/jenkins/agent/workspace/MediaTagger_master/deploy/MediaTagger/*.* ~/prod/deploy/MediaTagger/linux-musl-x64'
               
            }
        }
    }
}
