using UnityEngine;
using System.Collections;

namespace BJ
{
    // What is the difference between internal class and internal function and internal variable
    // Why use internal?
    internal class SceneTransitionerHelper : SingletonGameObject<SceneTransitionerHelper>
    {
        internal void LoadNewScene(string SceneName)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
            StartCoroutine(LoadLevelAnim(SceneName));
            Debug.Log("How many times does LoadScene get called?");
        }

        private IEnumerator LoadLevelAnim(string SceneName)
        {
            AsyncOperation loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

            while (!loadOperation.isDone)
            {
                /*float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
                Debug.Log(loadOperation.progress);

                int image = Mathf.RoundToInt(progress / 0.25f);
                if (image >= 5)
                {
                    image = 4;
                }
                trainIcon.sprite = trainFrames[image];*/

                yield return null;
            }
        }
    }
}