using UnityEngine;
using MyNameSpace;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite[] switchs;
    int nowIndex = 0;
    private void OnMouseDown()
    {
        if (Dialogue.nowIndex >= 7)
        {
            MyObject.Find("AudioSet/SwitchLight").GetComponent<AudioSource>().Play();
            nowIndex = (nowIndex + 1) % 2;
            GetComponent<SpriteRenderer>().sprite = switchs[nowIndex];
            transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(nowIndex == 1 ? true : false);
            if (Dialogue.nowIndex == 7)
            {
                GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }
}
