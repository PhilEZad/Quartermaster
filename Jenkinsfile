pipeline {
  agent any
  stages {
    stage("Verify Tooling") {
      steps {
        sh '''
        docker info
        docker version
        docker compose version
        '''
		}
	}
		stage("Cleaning") {
      steps {
		echo "Cleaning..."
		sh 'docker system prunte -a ---volumes -f'
		echo "Cleaning complete."

		}
	}
	stage("Build") {
      steps {
		echo "Building..."
		sh 'docker compose up -d'
		echo "Build complete."

		}
	}
}}