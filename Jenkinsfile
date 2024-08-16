@Library('Unity-Pipeline-Shared-Library') _

pipeline
{
    agent none

    stages
    {
        /*stage('Build-Windows')
        {
            agent { label 'ngrokagent2'}
            steps
            {
                buildWindows()
            }
        }
        stage('Upload-Windows')
        {
            agent { label 'ngrokagent2' }
            steps
            {
                compressWindowsBuild()
                uploadWindowsToAWS()
            }
        }*/
        stage('Build-Linux')
        {
            agent { label 'ngrokagent1' }
            steps
            {
                buildLinux()
            }
        }
        stage('Upload-Linux')
        {
            agent { label 'ngrokagent1' }
            steps
            {
                compressLinuxBuild()
                uploadLinuxToAWS()
            }
        }
        stage('Build-WebGL')
        {
            agent { label 'ngrokagent1' }
            steps
            {
                buildWebGL()
            }
        }
        stage('Upload-WebGL')
        {
            agent { label 'ngrokagent1' }
            steps
            {
                uploadWebGLToAWS()
            }
        }
        stage('Discord-Notification')
        {
            agent {label 'ngrokagent1'}
            steps {
                script {
                    withCredentials([string(credentialsId: 'discord_webhook', variable: 'WEBHOOK_URL')]) {
                        //make sure ?thread_id=${threadId} is appended to the webhook
                        def webhookUrl = "${WEBHOOK_URL}"
                
                        def presignedUrlLinux = sh(
                            script: """
                                aws s3 presign s3://linux-build/Build-Linux.zip --expires-in 3600
                            """,
                            returnStdout: true
                        ).trim()

                        def presignedUrlWindows = sh(
                            script: """
                                aws s3 presign s3://window-build/Build-Windows.zip --expires-in 3600
                            """,
                            returnStdout: true
                        ).trim()

                        def websiteEndpoint = "http://webgl-unitybuild.s3-website-us-west-2.amazonaws.com"
                        // Construct the JSON payload with proper escaping
                        def payload = "{\"content\": \"Build is complete.\\nLinux Build link: ${presignedUrlLinux}\\nWindows Build: ${presignedUrlWindows}\\n\\nWebGL Build link: ${websiteEndpoint}\"}"

                        sh """
                            curl -X POST -H 'Content-Type: application/json' -d '${payload}' '${webhookUrl}'
                        """
                    }
                }
            }
        }
    }
    

    /*post {
        success {
            agent {label 'controller'}
            // Send a POST request to the Discord webhook URL
            script {
                withCredentials([string(credentialsId: 'discord_webhook', variable: 'WEBHOOK_URL')]) {
                    //make sure ?thread_id=${threadId} is appended to the webhook
                    def webhookUrl = "${WEBHOOK_URL}"
                
                    def presignedUrl = sh(
                        script: """
                            aws s3 presign s3://linux-build/Build-Linux.zip --expires-in 3600
                        """,
                        returnStdout: true
                    ).trim()

                    def websiteEndpoint = "http://webgl-hostbuild.s3-website-us-west-2.amazonaws.com"
                    // Construct the JSON payload with proper escaping
                    def payload = "{\"content\": \"Build is complete.\\n\\nWebGL Build link: ${websiteEndpoint}\\nLinux Build link: ${presignedUrl}\"}"

                    sh """
                        curl -X POST -H 'Content-Type: application/json' -d '${payload}' '${webhookUrl}'
                    """
                }
            }
        }
    }*/
}