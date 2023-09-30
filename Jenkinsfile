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
	}
}