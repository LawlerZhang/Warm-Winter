using UnityEngine;
using System.Collections.Generic;
using MyNameSpace;

public class Test : MonoBehaviour
{
    //[SerializeField] string ABC;
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            foreach(KeyValuePair<string,int>i in Directory.dic)
            {
                print(i);
            }
       }
    }
}
