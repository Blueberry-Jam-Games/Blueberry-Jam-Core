pipeline
{
    agent any
    stages
    {
        stage("Update")
        {
            steps
            {
                echo 'Update is being called'
                git pull
            }
        }
        stage('Build')
        {
            steps
            {
                "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWindows -quit
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