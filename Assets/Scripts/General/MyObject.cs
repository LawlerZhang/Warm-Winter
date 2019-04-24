using UnityEngine;
using System.Collections.Generic;

namespace MyNameSpace
{
    public class MyObject : MonoBehaviour
    {
        public static void SetObjectActive(GameObject _Object, bool sign = true)
        {
            _Object.SetActive(sign);
        }
        public static void SetObjectActive(string path, bool sign = true)
        {
            GameObject _Object = GameObject.Find(path);
            if (_Object)
                _Object.SetActive(sign);
            else
                SetObjectActive(Directory.dic, path, sign);
        }
        static void SetObjectActive(Dictionary<string, int> dic, string path, bool sign = true)
        {
            GameObject.Find(MyString.CutTail(path, '/')).transform.GetChild(dic[path]).gameObject.SetActive(sign);
        }
        public static GameObject Find(string path)
        {
            GameObject _Object;
            _Object = GameObject.Find(path);
            if (_Object == null)
                _Object = GameObject.Find(MyString.CutTail(path, '/')).transform.GetChild(Directory.dic[path]).gameObject;
            return _Object;
        }
    }
}
