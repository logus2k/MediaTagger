pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:v3'

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

        /*
        stage('Sonarqube') {
            steps {

                withSonarQubeEnv('sonarqube') {

                    sh 'dotnet-sonarscanner begin /k:\"MediaTagger\"'
                    sh 'dotnet build --no-restore'
                    sh 'dotnet-sonarscanner end'

                }

            }
        }
        */


        stage('Deploy') {
            steps {
                
                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --no-restore --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
