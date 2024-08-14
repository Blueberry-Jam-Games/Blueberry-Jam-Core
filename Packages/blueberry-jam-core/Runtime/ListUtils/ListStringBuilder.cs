using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BJ
{
    public class ListStringBuilder : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public delegate String Stringifier(UnityEngine.Object obj);
        StringBuilder sb;

        public String Stringify(IList<UnityEngine.Object> ts) {
            sb = new StringBuilder();
            foreach (var item in ts)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        public String StringifyMeDelegate(IList<UnityEngine.Object> ts, Stringifier del) {
            sb = new StringBuilder();
            foreach (var item in ts)
            {
                sb.Append(del(item));
            }
            return sb.ToString();
        }
    }
}
