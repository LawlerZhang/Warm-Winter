using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    string[] taskTest = new string[20];
    int nowIndex = 0;
    void Awake()
    {
        taskTest[0] = ("驱赶房前的流浪狗(提示：点击狗)");
        taskTest[1] = ("回家");
        taskTest[2] = ("打开任意一盏灯");
        taskTest[3] = ("去冰箱找点东西");
        taskTest[4] = ("在二楼找到电话机打电话叫车去麦肯基");
        taskTest[5] = ("出门");
        taskTest[6] = ("上车（提示：点击出租车来上车）");
        taskTest[7] = ("进入麦肯基大吃一顿（提示：点击麦肯基）");
        taskTest[8] = ("去床上睡觉");
        taskTest[9] = ("向东走寻找避寒的地方");
        taskTest[10] = ("去楼下走走");
        taskTest[11] = ("跟随小女孩");
        taskTest[12] = ("去厕所睡觉");
        taskTest[13] = ("下楼看看");
        taskTest[14] = ("朝小偷吠");
        taskTest[15] = ("向西走");
        taskTest[16] = ("继续向西走");
        taskTest[17] = ("去杨毅家旁边避寒");
        taskTest[18] = ("出门寻找流浪狗");
        taskTest[19] = ("走向流浪狗");
    }
    private void OnEnable()
    {
        GetComponent<Text>().text = taskTest[nowIndex];
        nowIndex++;
        GetComponent<Task>().enabled = false;
    }
}
