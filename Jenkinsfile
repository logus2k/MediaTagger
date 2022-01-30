pipeline {
    agent {
        docker { 
      
          image 'mydotnet'
          label 'mydotnet_image'

        }
        
    }
    stages {
         stage('Restore') {
            steps {

                bat 'dotnet restore'

            }
        }
        stage('Build') {
            steps {
               
                bat 'dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }
        stage('Deploy') {
            steps {

                bat 'mkdir deploy'
                bat 'dotnet publish --self-contained --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
               
            }
        }
    }
}
