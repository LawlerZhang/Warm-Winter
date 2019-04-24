using UnityEngine;
using MyNameSpace;
using UnityEngine.UI;

public class Action : MonoBehaviour
{
    public static bool can_click = false; //没啥用，删除
    public static int i = 0;  //没啥用 删除
    [SerializeField] GameObject[] WaitClickedTargets;
    string[] actionTexts = new string[7] { "驱  赶", "打  开", "拨  打", "乘  坐", "进  店", "睡  觉", "吠 叫" };
    int nowIndex = 0;
    public void Click()
    {
        if (nowIndex <= WaitClickedTargets.Length - 1)
        {
            WaitClickedTargets[nowIndex].GetComponent<ClickTarget>().Respond();
        }
        nowIndex++;
        MyObject.SetObjectActive("Canvas/Option", false);
    }
    private void OnEnable()
    {
        transform.GetChild(0).GetComponent<Text>().text = actionTexts[nowIndex];
    }
}