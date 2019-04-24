using UnityEngine;
using UnityEngine.SceneManagement;
using MyNameSpace;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] string buttonName;
    public void Click()
    {
        switch (buttonName)
        {
            case "ComeDown":
                {
                    GameObject _Player = MyPlayer.GetPlayer();
                    _Player.transform.position = new Vector3(239.59f, -0.38f, -0.2f);
                    break;
                }
            case "ComeUp":
                {
                    GameObject _Player = MyPlayer.GetPlayer();
                    _Player.transform.position = new Vector3(239.59f, 1.86f, -0.2f);
                    break;
                }
            case "ControlsButton":
                {
                    GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);
                    break;
                }
            case "CreditsButton":
                {
                    GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
                    break;
                }
            case "ExitGameButton":
                {
                    Application.Quit();
                    break;
                }
            case "ExitHome":
                {
                    MyObject.Find("AudioSet/BGM").GetComponent<BGMManager>().PlayBGM("Main_background_music");
                    GameObject.Find("YangYi").transform.position = new Vector3(9.8f, -0.3f, -0.2f);
                    GameObject.Find("Camera").transform.position = new Vector3(10.8f, 2, -10);
                    GameObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().enabled = true;
                    gameObject.SetActive(false);
                    break;
                }
            case "GoHome":
                {
                    MyObject.Find("AudioSet/BGM").GetComponent<BGMManager>().PlayBGM("YangHome");
                    GameObject.Find("YangYi").transform.position = new Vector3(220.0f, -0.3f, -0.2f);
                    GameObject.Find("Camera").transform.position = new Vector3(220, 2, -10);
                    GameObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().enabled = false;
                    if (Dialogue.nowIndex == 22)
                    {
                        MyObject.SetObjectActive("PropSet/Taxi", false);
                    }
                    gameObject.SetActive(false);
                    break;
                }
            case "MainMenuButton":
                {
                    SceneManager.LoadScene("StartScene");
                    break;
                }
            case "MaximizeButton":
                {
                    GameObject.Find("Canvas/Task").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.Find("Canvas/Task").transform.GetChild(1).gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    break;
                }
            case "MinimizeButton":
                {
                    GameObject.Find("Canvas/Task/Title").gameObject.SetActive(false);
                    GameObject.Find("Canvas/Task/List").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
                    break;
                }
            case "PassBy":
                {
                    GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
                    break;
                }
            case "StartGameButton":
                {
                    SceneManager.LoadScene("MainScene");
                    break;
                }
            case "StoryButton":
                {
                    GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(true);
                    break;
                }
            default:
                break;
        }
    }
}
