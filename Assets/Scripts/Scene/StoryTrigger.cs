using UnityEngine;
using MyNameSpace;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] string eventName;
    [SerializeField] int neededIndex;
    private void Awake()
    {
        Directory.Initialize();
    }
    private void Update()
    {
        if (neededIndex == Dialogue.nowIndex)
            Activate();
    }
    void Activate()           //激活触发器
    {
        GameObject target = MyPlayer.GetPlayer();
        if (MySpace.IsInArea2D(target, gameObject, 0.4f))
        {
            gameObject.SetActive(false);
            switch (eventName)
            {
                case "DriveDog":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");  //激活对话框
                        break;
                    }
                case "NightFall":
                    {
                        MyObject.SetObjectActive("Canvas/Aside");
                        MyObject.SetObjectActive("PropSet/Taxi");
                        MyObject.SetObjectActive("NPC/Huskie", false);
                        WeatherManager.Alternate();
                        break;
                    }
                case "TakeCar":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");  //激活对话框
                        break;
                    }
                case "FeelCold":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "Faint":
                    {
                        MyObject.Find("NPC/Puppy").GetComponent<PlayerStatus>().Faint();
                        MyObject.SetObjectActive("NPC/Girl");
                        break;
                    }
                case "FirstInGirlHome":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "SeeGirlFather":
                    {
                        MyObject.SetObjectActive("Canvas/Aside");
                        WeatherManager.Alternate();
                        MyObject.SetObjectActive("NPC/Father");
                        MyObject.SetObjectActive("NPC/Mother");
                        MyObject.Find("NPC/Puppy").GetComponent<PlayerController>().SetDirection(1);
                        break;
                    }
                case "CallGirl":
                    {
                        MyObject.Find("NPC/Girl").GetComponent<GirlBehaviour>().SetStatus(1);
                        break;
                    }
                case "FatherMoveToSleep":
                    {
                        MyObject.Find("NPC/Father").GetComponent<FatherBehaviour>().SetStatus(0);
                        break;
                    }
                case "MotherLeaveHome":
                    {
                        MyObject.Find("NPC/Mother").GetComponent<MotherBehaviour>().SetStatus(0);
                        break;
                    }
                case "FollowGirlTerminal":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "ReturnBedroom":
                    {
                        MyObject.Find("NPC/Girl").GetComponent<GirlBehaviour>().SetStatus(2);
                        break;
                    }
                case "GirlSleep":
                    {
                        MyObject.Find("GirlHome/GirlBed").GetComponent<FurnitureBehaviour>().ChangeSprite(1);
                        MyObject.SetObjectActive("NPC/Girl", false);
                        break;
                    }
                case "PuppySleep":
                    {
                        MyObject.Find("NPC/Puppy").GetComponent<PlayerStatus>().Faint();
                        Invoke("ActiveAside", 2.0f);
                        Invoke("PuppyWakeUp", 2.0f);
                        break;
                    }
                case "EncounterThief":
                    {
                        MyObject.SetObjectActive("NPC/Thief");
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "EncounterStranger":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        Invoke("GetBack", 2.0f);
                        break;
                    }
                case "HuskieSleep":
                    {
                        MyObject.Find("NPC/Huskie").transform.position = new Vector3(13.4f, -0.08f, -0.05f);
                        MyObject.Find("NPC/Huskie").GetComponent<PlayerStatus>().Faint();
                        MyObject.SetObjectActive("NPC/DreamYang");
                        MyObject.Find("NPC/DreamYang").GetComponent<DreamYangBehaviour>().SetStatus(0);
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "SnowStop":
                    {
                        MyObject.SetObjectActive("Canvas/Aside");
                        MyObject.Find("SnowSet").GetComponent<SnowManager>().ShutdownAllChildren();
                        break;
                    }
                case "YangShout":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "SeeHuskie":
                    {
                        MyObject.SetObjectActive("Canvas/Dialogue");
                        break;
                    }
                case "ApprochHuskie":
                    {
                        MyObject.Find("NPC/Huskie").GetComponent<HuskieBehaviour>().enabled = true;
                        MyObject.Find("NPC/Huskie").GetComponent<HuskieBehaviour>().SetStatus(1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
    //小狗醒来
    void PuppyWakeUp()
    {
        MyObject.Find("NPC/Puppy").GetComponent<PlayerStatus>().WakeUp();
    }
    //激活旁白
    void ActiveAside()
    {
        MyObject.SetObjectActive("Canvas/Aside");
    }
    //
    void GetBack()
    {
        MyObject.SetObjectActive("Canvas/Aside");
        MyObject.SetObjectActive("NPC/Huskie");
        MyPlayer.SetPlayer("NPC/Huskie");
        MyObject.Find("NPC/Huskie").transform.position = new Vector3(21.0f, -0.2f, -0.2f);
        MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().transform.position = new Vector3(22.0f, 2, -10);
        MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().SetTarget(MyPlayer.GetPlayer());
        MyObject.Find("NPC/Huskie").GetComponent<PlayerController>().enabled = true;
        MyObject.Find("NPC/Huskie").GetComponent<PlayerController>().SetDirection(-1);
    }
}
