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
        //stage('Build-WebGL-Linux')
        //{
        //    steps
        //    {
                //sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -nographics -executeMethod JenkinsBuild.BuildWebGL -quit'
        //    }
        //}
        stage('Build-Linux')
        {
            steps
            {
                sh 'PROJECT_PATH=$(pwd)'
                sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -projectPath "$PROJECT_PATH" -nographics -executeMethod JenkinsBuild.BuildLinux -quit'
            }
        }
        stage('Upload Linux Build')
        {
            steps
            {
                withCredentials([usernamePassword(credentialsId: 'aws-credentials-id', 
                                                 usernameVariable: 'AWS_ACCESS_KEY_ID', 
                                                 passwordVariable: 'AWS_SECRET_ACCESS_KEY')]) {
                    sh '''
                        tar -zcvf Linux-Build.tar.gz Build
                        aws configure set aws_access_key_id $AWS_ACCESS_KEY_ID
                        aws configure set aws_secret_access_key $AWS_SECRET_ACCESS_KEY
                        aws s3 cp Linux-Build.tar.gz s3://linux-build/
                    '''
                }
            }
        }
        stage('Test')
        {
            steps
            {
                echo 'Testing...'
            }
        }
        stage('Deploy')
        {
            steps
            {
                echo 'Deploying...'
            }
        }
    }
    

    post {
        success {
            // Send a POST request to the Discord webhook URL
            script {
                def threadId = params.THREAD_ID

                def webhookUrl = 'https://discord.com/api/webhooks/1263347658672570461/_b8hUdMdXcqusvXVdMZcGQjvQBNzndutG1-RPgKqmVPcecw98IKnTSmkfKCCYLnxOtpa'
                
                // Construct the JSON payload with proper escaping
                def payload = "{\"content\": \"Build is complete.\"}"

                sh """
                    curl -X POST -H 'Content-Type: application/json' -d '${payload}' '${webhookUrl}'
                """
            }
        }
    }
}