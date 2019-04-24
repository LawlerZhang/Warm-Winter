using UnityEngine;
using UnityEngine.UI;
using MyNameSpace;

public class WeatherManager : MonoBehaviour
{
    static bool isDay = true;
    public static void Alternate()
    {
        isDay = !isDay;
        GameObject.Find("Camera/Background").GetComponent<ChangeBackground>().Change();
        MyObject.SetObjectActive("Camera/Sun", isDay);
        GameObject.Find("SunLight").GetComponent<Light>().intensity = isDay ? 1.0f : 0.0f;
        if (isDay)
            MyObject.Find("Canvas/Dialogue").GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        else
            MyObject.Find("Canvas/Dialogue").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
    }
}
