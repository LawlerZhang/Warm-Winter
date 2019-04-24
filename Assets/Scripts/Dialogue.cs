using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject Aside;
    [SerializeField] GameObject TaskText;
    float nowTime = 0.0f;     //当前时间
    public static int nowIndex = 0;        //当前对话数组下标
    void Update()
    {
        if (nowIndex <= StoryLineText.storyLine.Length - 1)
            Play();
    }
    private void Play()
    {
        if (nowTime == 0.0f)
        {
            GetComponent<Text>().text = StoryLineText.storyLine[nowIndex];
            PlayerController.canControl = false;
        }
        nowTime += Time.deltaTime;
        if (nowTime >= StoryLineText.interval[nowIndex])
        {
            nowTime = 0.0f;
            PlayerController.canControl = true;
            nowIndex++;
            if (StoryLineText.IsTaskPoint(nowIndex - 1))
            {
                //完成任务
                TaskText.GetComponent<Task>().enabled = true;
                gameObject.SetActive(false);
            }
            //是否是剧情停止的点
            if (StoryLineText.IsPausePoint(nowIndex - 1))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
