pipeline
{
    agent { label 'ngrokagent1' }
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

                        def threadId = params.THREAD_ID

                        def webhookUrl = 'https://discord.com/api/webhooks/1263347658672570461/_b8hUdMdXcqusvXVdMZcGQjvQBNzndutG1-RPgKqmVPcecw98IKnTSmkfKCCYLnxOtpa'
                        def payload = [
                            content: "Build is complete. You can download it (coming soon).",
                            thread_id: threadId
                        ]

                        def response = httpRequest(
                            httpMode: 'POST',
                            acceptType: 'APPLICATION_JSON',
                            contentType: 'APPLICATION_JSON',
                            url: webhookUrl,
                            requestBody: groovy.json.JsonOutput.toJson(payload)
                        )

                        echo "Discord webhook response: ${response}"
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
    
}