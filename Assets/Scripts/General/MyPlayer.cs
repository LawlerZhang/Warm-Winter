using UnityEngine;

namespace MyNameSpace
{
    public class MyPlayer : MonoBehaviour
    {
        static GameObject _Player = null;
        static GameObject defaultPlayer = null;
        public static void SetPlayer(string playerName)
        {
            if (_Player == null)
                _Player = GameObject.Find(playerName);
            else if (_Player.name != playerName)
            {
                _Player.gameObject.SetActive(false);
                _Player = MyObject.Find(playerName);
                _Player.gameObject.SetActive(true);
            }
        }
        public static GameObject GetPlayer()
        {
            return _Player;
        }
        public static void InitilalizePlayer()
        {
            defaultPlayer = MyObject.Find("YangYi");
            _Player = defaultPlayer;
        }
        public static void ResetPlayer()
        {
            _Player = defaultPlayer;
            _Player.SetActive(true);
        }
    }
}
