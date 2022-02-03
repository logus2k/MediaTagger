pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:latest'

        }
    }

    environment {
        
        DOTNET_CLI_HOME= '/tmp'
    
    }

    stages {
         
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
        stage('Deploy') {
            steps {

                sh 'mkdir deploy'
                sh 'dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
