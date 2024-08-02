using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BJ
{
    public class SceneTransitioner
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Init()
        {
            //Connor needs to create better variable name but is Lazy right now
            GameObject sceneTransitionerHelper = Resources.Load<GameObject>("SceneTransitionerConfig");
            if (sceneTransitionerHelper == null)
            {
                // If connor forgot to remove this comment or forgot to make the error message better, you should mock hime mercilessly 
                Debug.LogError("failed to load prefab");
            }

            GameObject instance = GameObject.Instantiate(sceneTransitionerHelper);
            if (instance == null)
            {
                // If connor forgot to remove this comment or forgot to make the error message better, you should mock him mercilessly 
                Debug.LogError("failed to instantiate object");
            }

            if (instance.TryGetComponent<SceneTransitionerHelper>(out SceneTransitionerHelper sch))
            {
                mSceneTransitionerHelper = sch;
            }
        }

        private static SceneTransitionerHelper mSceneTransitionerHelper;

        // Why static?
        // can static methods go in non static classes?
        // Where does SceneTransitioner live if not in DONOTDESTROY?
        public static void LoadNewScene(string SceneName)
        {
            mSceneTransitionerHelper.LoadNewScene(SceneName);
        }
    }
}