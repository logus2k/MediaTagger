pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:latest'

        }
    }

    environment {
        
        HOME = '/tmp'
    
    }

    stages {
         /*
         stage('Restore') {
            steps {

                sh 'dotnet restore'

            }
        }
        */
        stage('Build') {
            steps {
               
                sh '/usr/share/dotnet/dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }
        stage('Deploy') {
            steps {

                sh 'mkdir deploy'
                sh '/usr/share/dotnet/dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
