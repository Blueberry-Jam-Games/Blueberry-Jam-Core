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
        stage('Build-WebGL-Linux')
        {
            steps
            {
                sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -nographics -executeMethod JenkinsBuild.BuildWebGL -quit'
            }
        }
        stage('Build-Linux')
        {
            steps
            {
                sh '/opt/Unity/Hub/Editor/2022.3.21f1/Editor/Unity -batchmode -nographics -executeMethod JenkinsBuild.BuildLinux -quit'
            }
        }
        stage('Upload Linux Build')
        {
            steps
            {
                echo 'Uploading Linux Build'
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