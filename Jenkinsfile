pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:v2'

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
               
                sh 'dotnet build --configuration Release ./MediaTagger.csproj'           
               
            }
        }

        stage('Sonarqube') {
            steps {

                withSonarQubeEnv('sonarqube') {

                    sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"MediaTagger\""
                    sh "dotnet build"
                    sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"

                }

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
