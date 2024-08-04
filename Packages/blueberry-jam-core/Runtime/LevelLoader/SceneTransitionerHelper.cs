using System.Collections;
using Codice.Client.BaseCommands.TubeClient;
using UnityEngine;
using UnityEngine.UI;

namespace BJ
{
    internal class SceneTransitionerHelper : SingletonGameObject<SceneTransitionerHelper>
    {
        [Header("Game Object References")]
        [SerializeField] private CanvasGroup Crossfade;
        [SerializeField] private Image LoadingIcon;
        [Header("Animation Reference Storage")]
        [SerializeField] private Sprite[] Frames;

        [Header("Animation Configuration")]
        [SerializeField] private float TransitionTime = 1f;
        [SerializeField] private AnimationCurve EaseTransitionCurve;

        /* ----- Helper Variables -----*/
        private float StartTransitionTime;

        protected override void Awake()
        {
            base.Awake();
            Assertions();

            StartTransitionTime = 0.0f;
        }

        internal void LoadNewScene(string SceneName)
        {
            StartCoroutine(LoadLevelAnim(SceneName));
        }

        private IEnumerator LoadLevelAnim(string SceneName)
        {

            Assertions();

            /* ----- Fade to black (Start) ----- */
            Crossfade.gameObject.SetActive(true);
            LoadingIcon.sprite = Frames[0];

            StartTransitionTime = Time.time;
            while (Time.time - StartTransitionTime < TransitionTime)
            {
                Crossfade.alpha = EaseTransitionCurve.Evaluate(Time.time - StartTransitionTime);
                yield return null;
            }
            /* ----- Fade to black (End) */

            /* ----- Load Level (Start) ----- */
            AsyncOperation load_operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

            int i = 0;
            while (!load_operation.isDone)
            {
                if (i >= Frames.Length)
                {
                    i = 0;
                }

                LoadingIcon.sprite = Frames[i];

                i++;
                yield return null;
            }
            /* ----- Load Level (End) ----- */

            /* ----- Unfade from black (Start) ----- */
            StartTransitionTime = Time.time;
            while (Time.time - StartTransitionTime < TransitionTime)
            {
                Crossfade.alpha = EaseTransitionCurve.Evaluate(TransitionTime - (Time.time - StartTransitionTime));
                yield return null;
            }
            Crossfade.gameObject.SetActive(false);
            /* ----- Unfade from black (End) ----- */
        }

        private void Assertions()
        {
            Debug.Assert(Frames.Length > 0, "The Configuration Prefab for the Scene Transitioner has no Frames. Please add some so that you can indicate to the user that a level is loading");
            Debug.Assert(Crossfade != null, "Crossfade GameObject is not set. Please assign it so that the Scene Transitioner can fade to black and lift the black when level loading is complete");
            Debug.Assert(LoadingIcon != null, "LoadingIcon GameObject is not set. Please assign it so that the sprites that you have specified in 'Frames' will be displayed on the screen");
            Debug.Assert(EaseTransitionCurve != null, "EaseTransitionCurve is not set. Please specify an AnimationCurve so that you can specify the speed at which the screen fades to black and lifts the blackout");
        }
    }
}