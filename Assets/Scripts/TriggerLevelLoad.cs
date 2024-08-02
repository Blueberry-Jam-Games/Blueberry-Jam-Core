using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelLoad : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            BJ.SceneTransitioner.LoadNewScene("ConnorTestScene");
        }
    }
}
