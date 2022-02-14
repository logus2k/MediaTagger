pipeline {

    agent {
        any {
            docker { 
      
                image 'mydotnet_sdk:v0'
                args '-u root --network jenkins -e SONAR_HOST_URL=\"http://quasar:9000\"'

            }
        }
    }

    stages {
         
        stage('Build') {
            steps {

                sh 'cat /etc/passwd'
                sh 'whoami'
                
                sh 'dotnet sonarscanner begin /k:"MediaTagger" /d:sonar.host.url="http://quasar:9000" /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

                sh 'dotnet build'
            
                sh 'dotnet sonarscanner end /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

            }
        }

        stage('Deploy') {
            steps {
                
                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --no-restore --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
