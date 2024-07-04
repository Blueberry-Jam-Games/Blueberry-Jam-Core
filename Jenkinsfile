pipeline
{
    agent any
    stages
    {
        stage('Build')
        {
            steps
            {
                bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWindows -quit -logfile build.log'
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