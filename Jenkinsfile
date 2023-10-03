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
		sh 'docker system prune -a --volumes -f'
		echo "Cleaning complete."

		}
	}
	stage("Setup") {
      steps {
		echo "Running setup..."
		sh 'docker compose up -d'
		sh 'RUN npm install'
		echo "Setup complete."
		}
	}
	stage("Build") {
      steps {
		echo "Building..."
		sh 'RUN dotnet build'
		echo "Build complete."
		}
	}
}}