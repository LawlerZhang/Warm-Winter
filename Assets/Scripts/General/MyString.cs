using UnityEngine;

namespace MyNameSpace
{
    public class MyString : MonoBehaviour
    {
        //获取从ch开始的尾部
        public static string GetTail(string str, char ch)
        {
            string _str = "";
            int i;
            for (i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ch)
                    break;
            }
            if (i == -1) return "";
            for (i++; i < str.Length; i++)
                _str += str[i];
            return _str;
        }
        //删去从ch开始的尾部
        public static string CutTail(string str, char ch)
        {
            string _str = "";
            int i, j;
            for (j = str.Length - 1; j >= 0; j--)
            {
                if (str[j] == ch)
                    break;
            }
            if (j == -1) return "";
            for (i = 0; i < j; i++)
                _str += str[i];
            return _str;
        }
    }
}
