using System;
using UnityEngine;

public class LoadNextLevelScript : MonoBehaviour
{
    [SerializeField] private string NextScene;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow)) // Replace KeyCode.Space with the key you're interested in
        {
            BJ.SceneTransitioner.LoadNewScene(NextScene);
        }
    }
}
