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
            //SceneTransitooner st = 
            BJ.SceneTransitioner.Instance.LoadNewScene("ConnorTestScene");
        }
    }
}
