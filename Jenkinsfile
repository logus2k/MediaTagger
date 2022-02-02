pipeline {

    agent any 

    stages {

        agent { docker { image 'mydotnet_sdk:latest' } }
        
        stage('Restore') {
            steps {

                sh 'dotnet restore'

            }
        }
        
        stage('Build') {
            steps {
               
                sh 'dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }

        stage('Test') {
            steps {

                sh 'dotnet test ./MediaTagger.csproj -c Release -r /results'

            }
        }

        stage('Deploy') {
            steps {

                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }

    }
}
