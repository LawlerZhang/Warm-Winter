using UnityEngine;
using System.Collections.Generic;

public class Directory : MonoBehaviour
{
    public static Dictionary<string, int> dic = new Dictionary<string, int>();
    public static void Initialize()
    {
        //Canvas
        if (!dic.ContainsKey("Canvas/Option"))
            dic.Add("Canvas/Option", 0);
        if (!dic.ContainsKey("Canvas/Task"))
            dic.Add("Canvas/Task", 1);
        if (!dic.ContainsKey("Canvas/MaximizeButton"))
            dic.Add("Canvas/MaximizeButton", 2);
        if (!dic.ContainsKey("Canvas/Dialogue"))
            dic.Add("Canvas/Dialogue", 3);
        if (!dic.ContainsKey("Canvas/Menu"))
            dic.Add("Canvas/Menu", 4);
        if (!dic.ContainsKey("Canvas/GoHome"))
            dic.Add("Canvas/GoHome", 5);
        if (!dic.ContainsKey("Canvas/ExitHome"))
            dic.Add("Canvas/ExitHome", 6);
        if (!dic.ContainsKey("Canvas/ComeUp"))
            dic.Add("Canvas/ComeUp", 7);
        if (!dic.ContainsKey("Canvas/ComeDown"))
            dic.Add("Canvas/ComeDown", 8);
        if (!dic.ContainsKey("Canvas/SettingButton"))
            dic.Add("Canvas/SettingButton", 9);
        if (!dic.ContainsKey("Canvas/Aside"))
            dic.Add("Canvas/Aside", 10);
        //PropSet
        if (!dic.ContainsKey("PropSet/Taxi"))
            dic.Add("PropSet/Taxi", 0);
        //NPC
        if (!dic.ContainsKey("NPC/Huskie"))
            dic.Add("NPC/Huskie", 0);
        if (!dic.ContainsKey("NPC/Puppy"))
            dic.Add("NPC/Puppy", 1);
        if (!dic.ContainsKey("NPC/Girl"))
            dic.Add("NPC/Girl", 2);
        if (!dic.ContainsKey("NPC/Father"))
            dic.Add("NPC/Father", 3);
        if (!dic.ContainsKey("NPC/Mother"))
            dic.Add("NPC/Mother", 4);
        if (!dic.ContainsKey("NPC/Thief"))
            dic.Add("NPC/Thief", 5);
        if (!dic.ContainsKey("NPC/Stranger"))
            dic.Add("NPC/Stranger", 6);
        if (!dic.ContainsKey("NPC/DreamYang"))
            dic.Add("NPC/DreamYang", 7);
        //
        if (!dic.ContainsKey("Camera/Background"))
            dic.Add("Camera/Background", 0);
        if (!dic.ContainsKey("Camera/Sun"))
            dic.Add("Camera/Sun", 1);
        //StoryTriggerSet
        if (!dic.ContainsKey("StoryTriggerSet/DriveDog"))
            dic.Add("StoryTriggerSet/DriveDog", 0);
        if (!dic.ContainsKey("StoryTriggerSet/NightFall"))
            dic.Add("StoryTriggerSet/NightFall", 1);
        if (!dic.ContainsKey("StoryTriggerSet/TakeCar"))
            dic.Add("StoryTriggerSet/TakeCar", 2);
        if (!dic.ContainsKey("StoryTriggerSet/FeelCold"))
            dic.Add("StoryTriggerSet/FeelCold", 3);
        if (!dic.ContainsKey("StoryTriggerSet/Faint"))
            dic.Add("StoryTriggerSet/Faint", 4);
    }
}
