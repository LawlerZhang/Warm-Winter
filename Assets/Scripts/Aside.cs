using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyNameSpace;

public class Aside : MonoBehaviour
{
    string[] asideText = new string[14];
    float nowTime = 0.0f;
    int nowIndex = 0;
    void Awake()
    {
        asideText[0] = ("故事发生在一个下着大雪的冬天。");
        asideText[1] = ("天黑了");
        asideText[2] = ("你在麦肯基大吃了一顿，90分钟后");
        asideText[3] = ("梦境");
        asideText[4] = ("小女孩家");
        asideText[5] = ("天黑了");
        asideText[6] = ("小狗就这样一直没被发现，直到一天晚上");
        asideText[7] = ("小狗被爸爸从家里丢了出来");
        asideText[8] = ("就这样，小狗一直流浪着，受尽路人的殴打与谩骂，小狗也变成了大狗");
        asideText[9] = ("梦醒了");
        asideText[10] = ("雪停了");
        asideText[11] = ("杨毅跟着狗跑了很久，最终还是跟丢了");
        asideText[12] = ("在这之后，杨毅开了个流浪狗收养中心,和流浪狗快乐得生活着");
        asideText[13] = ("全剧终");
    }
    void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = asideText[nowIndex];
        nowTime += Time.deltaTime;
        PlayerController.canControl = false;
        if (nowTime >= 3.0f && Dialogue.nowIndex != 76)
        {
            nowTime = 0.0f;
            nowIndex++;
            PlayerController.canControl = true;
            if (!StoryLineText.IsPausePoint(Dialogue.nowIndex - 1))
                MyObject.SetObjectActive("Canvas/Dialogue");
            if (!IsContinue(nowIndex))
                gameObject.SetActive(false);
            if (nowIndex == 14)
                SceneManager.LoadScene("StartScene");
        }
    }
    public void DelayActiveAside(float seconds)
    {
        nowTime = -seconds;
        gameObject.SetActive(true);
    }
    public void DelayActionObject(string objectName, float seconds)
    {
        nowTime = -seconds;
        MyObject.SetObjectActive(objectName);
    }
    bool IsContinue(int index)
    {
        if (index == 12 || index == 13)
            return true;
        return false;
    }
}
