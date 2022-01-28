pipeline {
    agent {
        docker {
            image 'mydotnet'
            label 'mydotnet'
        }
    stages {
        stage('Build') {
            steps {
                sh "dotnet build"
            }
        }
    }
}
