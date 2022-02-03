pipeline {

    agent any

    stages {
         
        stage('Restore') {

            agent {
                docker { 
            
                image 'mydotnet_sdk:v2'

                }
            }

            steps {

                sh 'dotnet restore'

            }
        }
        stage('Build') {

            agent {
                docker { 
            
                image 'mydotnet_sdk:v2'

                }
            }

            steps {
               
                sh 'dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }
        stage('Deploy') {

            agent {
                docker { 
            
                image 'mydotnet_sdk:v2'

                }
            }

            steps {

                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
