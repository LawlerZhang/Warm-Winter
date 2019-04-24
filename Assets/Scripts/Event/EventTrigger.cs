using UnityEngine;
using MyNameSpace;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] string triggerPointName;
    GameObject target;
    float nowTime = 0.0f;
    int nowFloorNum = 0;
    private void Update()
    {
        Event();
    }
    private void Event()
    {
        target = MyPlayer.GetPlayer();
        switch (triggerPointName)
        {
            case "ComeDown":
                {
                    if (MySpace.IsInArea2D(gameObject, target, 0.15f))
                        MyObject.SetObjectActive("Canvas/ComeDown");
                    else
                        MyObject.SetObjectActive("Canvas/ComeDown", false);
                    break;
                }
            case "ComeUp":
                {
                    if (MySpace.IsInArea2D(gameObject, target, 0.15f))
                        MyObject.SetObjectActive("Canvas/ComeUp");
                    else
                        MyObject.SetObjectActive("Canvas/ComeUp", false);
                    break;
                }
            case "ExitHome":
                {
                    if (Dialogue.nowIndex >= 15)
                    {
                        if (MySpace.IsInArea2D(gameObject, target, 0.4f))
                            MyObject.SetObjectActive("Canvas/ExitHome");
                        else
                            MyObject.SetObjectActive("Canvas/ExitHome", false);
                    }
                    break;
                }
            case "GoHome":
                {
                    if (target.name == "YangYi" && Dialogue.nowIndex >= 5 && !target.GetComponent<PlayerStatus>().isInCarrier)
                    {
                        if (MySpace.IsInArea2D(gameObject, target, 0.4f))
                            MyObject.SetObjectActive("Canvas/GoHome");
                        else
                            MyObject.SetObjectActive("Canvas/GoHome", false);
                    }
                    break;
                }
            case "UpDown_01":
                {
                    float deltaX = target.transform.position.x - transform.position.x;
                    if (deltaX > 0 && deltaX < 1.0f)
                    {
                        if (nowTime == 0.0f)
                        {
                            target.GetComponent<SpriteRenderer>().enabled = false;
                            target.GetComponent<PlayerController>().enabled = false;
                        }
                        nowTime += Time.deltaTime;
                        if (nowTime >= 3.0f)
                        {
                            target.GetComponent<SpriteRenderer>().enabled = true;
                            nowTime = 0.0f;
                            nowFloorNum = (nowFloorNum + 1) % 2;
                            if (nowFloorNum == 0)
                                target.transform.position = new Vector3(transform.position.x, -0.3f, -0.2f);
                            else if (nowFloorNum == 1)
                                target.transform.position = new Vector3(transform.position.x, 2.1f, -0.2f);
                            target.GetComponent<PlayerController>().SetDirection(-1);
                            target.GetComponent<PlayerController>().enabled = true;
                        }
                    }
                    break;
                }
        }
    }
}
