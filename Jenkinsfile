pipeline {
    agent {
        docker { 
      
          image 'mydotnet_sdk:v0'
          args '--network jenkins -e SONAR_HOST_URL=\"http://sonarqube:9000\"'

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

                    sh 'SONAR_HOST_URL=http://sonarqube:9000'
                    
                    sh 'dotnet build --no-restore'
                
                    // sh 'echo Scanner configuration file:'
                    // sh 'cat /tmp/.dotnet/tools/.store/dotnet-sonarscanner/5.4.1/dotnet-sonarscanner/5.4.1/tools/net5.0/any/sonar-scanner-4.6.2.2472/conf/sonar-scanner.properties'

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
