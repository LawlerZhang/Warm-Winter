using UnityEngine;

public class StoryLineText : MonoBehaviour
{
    public static string[] storyLine = new string[70];
    static int[] taskTriggerPoint = new int[20] { 1, 4, 6, 7, 10, 14, 15, 19, 21, 24, 32, 42, 49, 50, 51, 56, 57, 60, 67, 69 };
    static int[] asideTriggerPoint = new int[100];
    static int[] dialoguePausePoint = new int[9] { 2, 17, 19, 26, 35, 54, 61, 67, 68 };
    public static float[] interval = new float[100];
    void Awake()
    {
        storyLine[0] = ("杨毅：啊！好冷啊");
        storyLine[1] = ("杨毅：前面怎么有条野狗在我家旁边睡觉！！！");
        storyLine[2] = ("杨毅：快走开！野狗");
        storyLine[3] = ("杨毅：奇怪  那狗怎么不见了");
        storyLine[4] = ("算了，回家吧");
        storyLine[5] = ("天都黑了啊");
        storyLine[6] = ("开个灯吧");
        storyLine[7] = ("好饿啊！去冰箱找点吃的吧");
        storyLine[8] = ("T_T 冰箱内空空如也");
        storyLine[9] = ("算了！还是出去吃饭吧");
        storyLine[10] = ("要不叫辆车去吃麦肯基吧！");
        storyLine[11] = ("杨毅：喂！出租车司机吗？");
        storyLine[12] = ("司机：是的。");
        storyLine[13] = ("杨毅：我家在通运西路88号，快来载我");
        storyLine[14] = ("司机：好的，马上来");
        storyLine[15] = ("车已经到了");
        storyLine[16] = ("杨毅：我要去麦肯基");
        storyLine[17] = ("司机：好的");
        storyLine[18] = ("可以下车了");
        storyLine[19] = ("去麦肯基大吃一顿吧！");
        storyLine[20] = ("到家了");
        storyLine[21] = ("好困啊！睡觉吧");
        storyLine[22] = ("我这是在哪？");
        storyLine[23] = ("奇怪，我怎么变成一条狗了！");
        storyLine[24] = ("向前走看看有没有避寒的地方");
        storyLine[25] = ("好冷啊，我快冻僵了");
        storyLine[26] = ("我不行了 呃");
        storyLine[27] = ("女孩：小狗狗你醒来了");
        storyLine[28] = ("狗:（心想）我这是在哪");
        storyLine[29] = ("女孩：小狗狗啊，以后这里就是你的家哦");
        storyLine[30] = ("狗：（心想）我去，什么鬼");
        storyLine[31] = ("女孩：我好累先睡一会儿，你随意玩耍吧！");
        storyLine[32] = ("狗：（心想）算了，下楼走走吧");
        storyLine[33] = ("王达康：李惠，咱们家什么时候多了只狗？");
        storyLine[34] = ("李惠:我不知道啊");
        storyLine[35] = ("王达康：（大喊）王可，给我下来！");
        storyLine[36] = ("王可：爸爸，什么事？");
        storyLine[37] = ("王达康：这条野狗怎么回事？");
        storyLine[38] = ("王达康：和你说过多少次不要碰狗，多脏啊");
        storyLine[39] = ("王达康:爸爸上班累了，去睡觉了，你马上把它丢走！");
        storyLine[40] = ("李惠：小可啊，乖，听你爸爸的话");
        storyLine[41] = ("李惠：妈妈去上夜班了");
        storyLine[42] = ("王可：哎~ 小狗狗 和我来");
        storyLine[43] = ("王可：放心，我是绝对不会抛弃你的");
        storyLine[44] = ("王可：你就找个地方睡觉吧!");
        storyLine[45] = ("狗：（感动）呜呜~");
        storyLine[46] = ("王可：小狗狗你怎么哭了，你好像能听懂我说的话");
        storyLine[47] = ("王可：大概是我多想了，对了你还没有名字吧");
        storyLine[48] = ("王可：以后就叫你 小可爱吧！");
        storyLine[49] = ("狗：（无语）......");
        storyLine[50] = ("狗:（心想）楼下怎么有动静，去看看吧");
        storyLine[51] = ("啊，小偷，快叫几声");
        storyLine[52] = ("汪汪汪！");
        storyLine[53] = ("小偷：糟了，被发现了，快跑");
        storyLine[54] = ("王达康:是谁在楼下!");
        storyLine[55] = ("王达康:（大怒）你这条野狗怎么还没走！！！");
        storyLine[56] = ("在这转转吧，看有没有可以住的地方");
        storyLine[57] = ("野狗，走开！");
        storyLine[58] = ("狗：好冷啊，咦，前面不是我的家吗？");
        storyLine[59] = ("狗：（无奈）但我现在是条狗啊，进不去了");
        storyLine[60] = ("算了，在旁边避避寒吧!");
        storyLine[61] = ("梦中杨毅：快走开，野狗!");
        storyLine[62] = ("杨毅：原来是个梦啊，终于结束了");
        storyLine[63] = ("杨毅想了一想");
        storyLine[64] = ("杨毅:但是，这梦感觉好真实啊");
        storyLine[65] = ("杨毅:不对，被我赶走的那条流浪狗呢？");
        storyLine[66] = ("杨毅:该不会已经冻死了吧！");
        storyLine[67] = ("杨毅：不行，我要去找它");
        storyLine[68] = ("杨毅:（大喊）小可爱，你在哪？");
        storyLine[69] = ("在前面！");
        for (int i = 0; i < interval.Length; i++)
            interval[i] = 3.5f;
    }
    public static bool IsTaskPoint(int point)
    {
        for (int i = 0; i < taskTriggerPoint.Length; i++)
        {
            if (point == taskTriggerPoint[i] && point != 0)
                return true;
        }
        return false;
    }
    public static bool IsAsidePoint(int point)
    {
        for (int i = 0; i < asideTriggerPoint.Length; i++)
        {
            if (point == asideTriggerPoint[i] && point != 0)
                return true;
        }
        return false;
    }
    public static bool IsPausePoint(int point)
    {
        for (int i = 0; i < dialoguePausePoint.Length; i++)
        {
            if (point == dialoguePausePoint[i] && point != 0)
                return true;
        }
        return false;
    }
}
