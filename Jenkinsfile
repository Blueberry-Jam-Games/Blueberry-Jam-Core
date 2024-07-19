pipeline
{
    agent { label 'ngrokagent1' }

     parameters {
        string(name: 'THREAD_ID', defaultValue: '', description: 'Discord thread ID to send the notification')
    }

    stages
    {
        //stage('Build-Windows')
        //{
        //    steps
        //    {
        //        bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWindows -quit'
        //    }
        //}
        //stage('Build-WebGL')
        //{
        //    steps
        //    {
        //        bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWebGL -quit'
        //    }
        //}
        stage('Build-WebGL-Linux')
        {
            steps
            {
                sh 'PROJECT_PATH=$(pwd)'
                sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -projectPath "$PROJECT_PATH" -nographics -executeMethod JenkinsBuild.BuildWebGL -quit'
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
                        aws s3 cp Build/WebGL s3://webgl-deploy/
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
    }
    

    post {
        success {
            // Send a POST request to the Discord webhook URL
            script {
                def threadId = params.THREAD_ID

                //make sure ?thread_id=${threadId} is appended to the webhook
                def webhookUrl = "?thread_id=${threadId}"
                
                // Construct the JSON payload with proper escaping
                def payload = "{\"content\": \"Build is complete.\"}"

                sh """
                    curl -X POST -H 'Content-Type: application/json' -d '${payload}' '${webhookUrl}'
                """
            }
        }
    }
}