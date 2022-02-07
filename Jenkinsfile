pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:v5'
          args '--network jenkins'

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
               
                sh 'dotnet build --no-restore --configuration Release ./MediaTagger.csproj'           
               
            }
        }

        stage('Sonarqube') {
            steps {

                withSonarQubeEnv('sonarqube') {

                    sh 'dotnet-sonarscanner begin /k:\"MediaTagger\" /d:sonar.login=\"c193c2ae68578f1a4fa8e5f4ab52052484c8cc8b\" /d:sonar.host.url=http://sonarqube:9000'
                    sh 'dotnet build --no-restore'
                    sh 'dotnet-sonarscanner end /d:sonar.login=\"c193c2ae68578f1a4fa8e5f4ab52052484c8cc8b\"'

                }

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
