pipeline {

    'agent any' {

        stages {
            
            stage('Build') {

                agent {

                    docker { 
                
                        image 'mydotnet_sdk:v0'
                        args '-u root --network jenkins -e SONAR_HOST_URL=\"http://quasar:9000\"'

                    }
                }                    
    
                steps {

                    sh 'cat /etc/passwd'
                    sh 'whoami'
                    
                    sh '/usr/share/dotnet/dotnet sonarscanner begin /k:"MediaTagger" /d:sonar.host.url="http://quasar:9000" /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

                    sh '/usr/share/dotnet/dotnet build'
                
                    sh '/usr/share/dotnet/dotnet sonarscanner end /d:sonar.login="e5bf76ebefb345914bbb3845aba63949104d6c83"'

                }
            }

            stage('Deploy') {
                steps {
                    
                    sh 'mkdir deploy'
                    sh '/usr/share/dotnet/dotnet publish --self-contained --no-restore --runtime win-x64 -c Release ./MediaTagger.csproj -o ./deploy/MediaTagger'            
                
                }
            }
        }
    }
}
