using UnityEngine;
namespace MyNameSpace
{
    public class MySpace : MonoBehaviour
    {
        //用于判断个游戏对象的平面距离是否在半径之内
        public static bool IsInArea2D(GameObject _Object1, GameObject _Object2, float radius)
        {
            float deviationX = Mathf.Abs(_Object1.transform.position.x - _Object2.transform.position.x);
            float deviationY = Mathf.Abs(_Object1.transform.position.y - _Object2.transform.position.y);
            if (Mathf.Pow(deviationX, 2) + Mathf.Pow(deviationY, 2) <= Mathf.Pow(radius, 2))
                return true;
            return false;
        }
    }
}
