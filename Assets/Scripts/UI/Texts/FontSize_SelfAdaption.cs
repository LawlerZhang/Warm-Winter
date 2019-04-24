using UnityEngine;
using UnityEngine.UI;

public class FontSize_SelfAdaption : MonoBehaviour
{
    int nowFontSize;
    private void Awake()
    {
        nowFontSize = GetComponent<Text>().fontSize;
    }
    void Start()
    {
        int size1 = (int)Mathf.Ceil(nowFontSize / 1920.0f * Screen.width);
        int size2 = GetComponent<Text>().fontSize = (int)Mathf.Ceil(nowFontSize / 1080.0f * Screen.height);
        GetComponent<Text>().fontSize = size1 <= size2 ? size1 : size2;
    }
}
