using UnityEngine;
using MyNameSpace;

public class InitializeGame : MonoBehaviour
{
    private void Awake()
    {
        MyPlayer.InitilalizePlayer();
        MyPlayer.SetPlayer("YangYi");
        Directory.Initialize();
    }
}
