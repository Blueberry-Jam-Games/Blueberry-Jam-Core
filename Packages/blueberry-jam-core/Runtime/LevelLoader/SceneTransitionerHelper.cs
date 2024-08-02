using UnityEngine;
using System.Collections;

namespace BJ
{
    public class SceneTransitioner : SingletonGameObject<SceneTransitioner>
    {
        public void LoadNewScene(string SceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
            //StartCoroutine(LoadLevelAnim(SceneName));
        }

        /*private IEnumerator LoadLevelAnim(string SceneName)
        {
            yield return null;
        }*/
    }
}