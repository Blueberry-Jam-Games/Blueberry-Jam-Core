using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPackage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HelloRuntime hrt = GetComponent<HelloRuntime>();
        hrt.ExternalCall();
        Debug.Log(ZC.HelloNamespaced.NonComponentAction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
