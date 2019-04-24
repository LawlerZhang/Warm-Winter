using UnityEngine;
using MyNameSpace;

public class ClickTarget : MonoBehaviour
{
    [SerializeField] string targetName;
    [SerializeField] int eventIndex;  //当前事件的位次
    bool canClick = true;
    public void Respond()
    {
        canClick = false;
        switch (targetName)
        {
            case "Huskie":
                {
                    MyObject.SetObjectActive("Canvas/Dialogue");
                    MyObject.Find("NPC/Huskie").GetComponent<HuskieBehaviour>().SetStatus(0);
                    break;
                }
            case "Fridge":
                {
                    MyObject.SetObjectActive("Canvas/Dialogue");
                    break;
                }
            case "Telephone":
                {
                    MyObject.SetObjectActive("Canvas/Dialogue");
                    break;
                }
            case "Taxi":
                {
                    HorizontalSmoothFollow.smoothing = 12.0f;
                    MyObject.SetObjectActive("Canvas/Dialogue");
                    MyObject.Find("YangYi").GetComponent<TakeCar>().GetOn();
                    GetComponent<TaxiBehaviour>().enabled = true;
                    break;
                }
            case "MCDonald":
                {
                    MyObject.SetObjectActive("Canvas/Aside");
                    HorizontalSmoothFollow.smoothing = 12.0f;
                    GameObject _Taxi = GameObject.Find("PropSet/Taxi");
                    if (_Taxi)
                    {
                        _Taxi.transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
                        _Taxi.transform.position = new Vector3(120.0f, 0.05f, -0.1f);
                    }
                    GameObject _Player = GameObject.Find("YangYi");
                    if (_Player)
                    {
                        _Player.transform.position = new Vector3(120.44f, 0.05f, 0.05f);
                        _Player.transform.localScale = new Vector3(-0.7f, 0.6f, 1.0f);
                        _Player.transform.parent = _Taxi.transform;
                        _Player.GetComponent<PlayerController>().enabled = false;
                        _Player.GetComponent<Animator>().enabled = false;
                        _Player.GetComponent<PlayerStatus>().isInCarrier = true;
                    }
                    if (_Taxi)
                        _Taxi.GetComponent<TaxiBehaviour>().enabled = true;
                    break;
                }
            case "Bed":
                {
                    MyObject.SetObjectActive("Canvas/Aside");
                    MyObject.SetObjectActive("NPC/Puppy");
                    MyPlayer.SetPlayer("NPC/Puppy");
                    MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().enabled = true;
                    MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().SetTarget(MyPlayer.GetPlayer());
                    WeatherManager.Alternate();
                    MyObject.Find("AudioSet/BGM").GetComponent<BGMManager>().PlayBGM("ColdWind");
                    break;
                }
            case "Thief":
                {
                    MyObject.SetObjectActive("Canvas/Dialogue");
                    Invoke("ThiefEscape", 3.0f);
                    break;
                }
            default:
                break;
        }
    }
    private void OnMouseDown()
    {
        if (eventIndex == Dialogue.nowIndex && canClick && MySpace.IsInArea2D(gameObject, MyPlayer.GetPlayer(), 2.0f))
            MyObject.SetObjectActive("Canvas/Option");
    }
    //小偷逃离
    void ThiefEscape()
    {
        MyObject.Find("NPC/Thief").GetComponent<ThiefBehaviour>().SetStatus(0);
    }
}
