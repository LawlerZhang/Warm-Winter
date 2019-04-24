using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] Sprite[] backgrounds;
    int nowIndex = 0;
    public void Change()
    {
        nowIndex = (nowIndex + 1) % 2;
        GetComponent<SpriteRenderer>().sprite = backgrounds[nowIndex];
    }
}
