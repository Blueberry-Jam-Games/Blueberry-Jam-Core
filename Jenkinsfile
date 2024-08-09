//@Library('Unity-Pipeline-Shared-Library') _

pipeline
{
    agent { label 'ngrokagent2' }

     parameters {
        string(name: 'THREAD_ID', defaultValue: '', description: 'Discord thread ID to send the notification')
    }

    stages
    {
        stage('Build-Windows')
        {
            steps
            {
                bat """
                    set PROJECT_PATH=%cd%
                    "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -projectPath "%PROJECT_PATH%" -nographics -executeMethod JenkinsBuild.BuildWindows -quit
                """
            }
        }
        /*stage('Build-WebGL-Linux')
        {
            steps
            {
                buildWebGL()
            }
        }
        stage('Upload WebGL Build')
        {
            steps
            {
                echo 'deploy WebGL build here'
                withCredentials([usernamePassword(credentialsId: 'aws-credentials-id', 
                                                 usernameVariable: 'AWS_ACCESS_KEY_ID', 
                                                 passwordVariable: 'AWS_SECRET_ACCESS_KEY')]) {
                    sh '''
                        aws configure set aws_access_key_id $AWS_ACCESS_KEY_ID
                        aws configure set aws_secret_access_key $AWS_SECRET_ACCESS_KEY
                        aws s3 cp Build/WebGL/Blueberry-Jam-Core s3://webgl-deploy/ --recursive
                    '''
                }
            }
        }
        stage('Build-Linux')
        {
            steps
            {
                sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -projectPath "$PROJECT_PATH" -nographics -executeMethod JenkinsBuild.BuildLinux -quit'
            }
        }
        stage('Upload Linux Build')
        {
            steps
            {
                sh '''
                    tar -zcvf Linux-Build.tar.gz Build
                    aws s3 cp Linux-Build.tar.gz s3://linux-build/
                '''
            }
        }
    }*/
    

    /*post {
        success {
            // Send a POST request to the Discord webhook URL
            script {
                def threadId = params.THREAD_ID

                withCredentials([string(credentialsId: 'discord_webhook', variable: 'WEBHOOK_URL')]) {
                    //make sure ?thread_id=${threadId} is appended to the webhook
                    def webhookUrl = "${WEBHOOK_URL}?thread_id=${threadId}"
                
                    def presignedUrl = sh(
                        script: """
                            aws s3 presign s3://linux-build/Linux-Build.tar.gz --expires-in 3600
                        """,
                        returnStdout: true
                    ).trim()

                    def websiteEndpoint = "http://webgl-deploy.s3-website-us-west-2.amazonaws.com"
                    // Construct the JSON payload with proper escaping
                    def payload = "{\"content\": \"Build is complete.\\n\\nWebGL Build link: ${websiteEndpoint}\\nLinux Build link: ${presignedUrl}\"}"

                    sh """
                        curl -X POST -H 'Content-Type: application/json' -d '${payload}' '${webhookUrl}'
                    """
                }
            }
        }*/
    }
}