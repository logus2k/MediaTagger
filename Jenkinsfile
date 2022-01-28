pipeline {
    agent {
        docker {
            image 'mydotnet'
            label 'mydotnet_container'
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
