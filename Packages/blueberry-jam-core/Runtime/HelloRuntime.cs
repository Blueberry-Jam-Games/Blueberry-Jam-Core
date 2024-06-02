using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloRuntime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Package Works");
    }

    public void ExternalCall()
    {
        Debug.Log("External function accessed file");
    }
}

namespace ZC
{
    public class HelloNamespaced
    {
        public static string NonComponentAction()
        {
            return "Hi I'm not a component";
        }
    }
}
