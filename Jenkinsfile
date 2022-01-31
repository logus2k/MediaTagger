pipeline {
    agent {
        docker { 
      
            image 'mydotnet_sdk:latest'

        }
    }
    stages {
         stage('Restore') {
            steps {

                sh 'dotnet restore'
                // sh 'dotnet --info'

            }
        }
        /*
        stage('Build') {
            steps {
               
                sh 'dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }
        stage('Deploy') {
            steps {

                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
        */
    }
}
