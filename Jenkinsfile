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
	stage("Build") {
      steps {
		echo "Building..."
		sh 'docker-compose up -d'
		echo "Build complete."

		}
	}
}}