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
		echo "Setup complete."
		}
	}
	stage("Build") {
      steps {
		echo "Building..."
		sh 'docker compose exec qm-frontend npm run build'
		sh 'docker compose exec qm-backend dotnet run'
		echo "Build complete."
		}
	}
		stage("Test") {
      steps {
		echo "Running tests..."
		echo "Testing complete."
		}
	}
  }
  post {
    always {
    // Stop and remove containers after the pipeline execution
    sh 'docker compose down'
    }
  }
}