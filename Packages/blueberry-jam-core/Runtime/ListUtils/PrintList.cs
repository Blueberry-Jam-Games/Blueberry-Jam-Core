using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BJ
{
    public class PrintList : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void PrintThisGO(List<GameObject> pop) {
            int i = 0;
            foreach (var item in pop)
            {
                Debug.Log("List item:" + i);
                Debug.Log("\n");
                i++;
                Debug.Log(item.ToString());
                Debug.Log("\n");
                Debug.Log("\n");
            }
        }
    }
}
