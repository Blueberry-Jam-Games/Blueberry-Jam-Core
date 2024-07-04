pipeline
{
    agent any
    stages
    {
        stage('Build-Windows')
        {
            steps
            {
                bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWindows -quit'
            }
        }
        stage('Build-WebGL')
        {
            steps
            {
                bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.21f1\\Editor\\Unity.exe" -batchmode -nographics -executeMethod JenkinsBuild.BuildWebGL -quit'
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