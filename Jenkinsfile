pipeline {
    agent {
        docker { 
            image 'mydotnet'
        }
    }
    stages {
        stage('Build') {
            steps {
                sh "dotnet build"
            }
        }
    }
}
