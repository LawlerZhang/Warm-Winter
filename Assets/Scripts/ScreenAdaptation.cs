using UnityEngine;

public class ScreenAdaptation : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
    }
}
