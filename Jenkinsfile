pipeline {

    agent { 
        label 'jenkinsagent01' 
    } 

    stages {

        stage('Restore') {

            agent { docker { image 'mydotnet_sdk:latest' } }

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
