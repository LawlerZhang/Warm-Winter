using UnityEngine;
using MyNameSpace;

public class TaxiBehaviour : MonoBehaviour
{
    float nowSpeed = 0.0f;    //当前速度
    float acceleratedSpeed = 4.0f;     //加速度
    float deceleratedSpeed = -7.5f;    //减速度
    float maxSpeed = 15.0f;              //最大速度
    float launchTime = 4.0f;           //汽车启动需要的时间
    float nowTime = 0.0f;
    float brakePointX1 = 125.0f, brakepointX2 = 21.0f;
    int audioStatus = -1;
    int direction = 1;  //行驶方向 1 or -1
    bool canActiveDialogue = true;
    GameObject[] Tyres = new GameObject[2];
    private void Awake()
    {
        //设置轮胎
        for (int i = 0; i <= 1; i++)
            Tyres[i] = transform.GetChild(i + 1).gameObject;
    }
    private void OnEnable()
    {
        canActiveDialogue = true;
        if (direction == -1)
        {
            nowTime = 4.0f;
            audioStatus = 0;
        }
    }
    void Update()
    {
        //启动
        if (nowTime < launchTime)
            Launch();
        //行驶
        else
        {
            Travel();
        }
    }
    void Launch()
    {
        if (audioStatus < 0)
        {
            GameObject.Find("AudioSet/LaunchCar").GetComponent<AudioSource>().Play();
            audioStatus = 0;
        }
        nowTime += Time.deltaTime;
    }
    void Travel()
    {
        if (audioStatus < 1)
        {
            GameObject.Find("AudioSet/MoveCar").GetComponent<AudioSource>().Play();
            audioStatus = 1;
        }
        if ((direction == 1 && transform.position.x >= brakePointX1) || (direction == -1 && transform.position.x <= brakepointX2))
        {
            Brake();
            return;
        }
        if (nowSpeed < maxSpeed)
            nowSpeed += acceleratedSpeed * Time.deltaTime;
        transform.Translate(direction * nowSpeed * Time.deltaTime, 0, 0);
        //旋转轮胎
        foreach (GameObject Tyre in Tyres)
        {
            Tyre.transform.Rotate(0, 0, -direction * nowSpeed * 190.0f);
        }
    }
    void Brake()
    {
        if (audioStatus < 2)
        {
            GameObject.Find("AudioSet/BrakeCar").GetComponent<AudioSource>().Play();
            GameObject.Find("AudioSet/MoveCar").GetComponent<AudioSource>().Stop();
            audioStatus = 2;
        }
        if (nowSpeed != 0.0f)
        {
            nowSpeed += deceleratedSpeed * Time.deltaTime;
            transform.Translate(direction * nowSpeed * Time.deltaTime, 0, 0);
        }
        if (nowSpeed <= 0.2f)
        {
            nowSpeed = 0.0f;
            nowTime += Time.deltaTime;
            //激活对话框
            if (canActiveDialogue)
            {
                MyObject.SetObjectActive("Canvas/Dialogue");
                canActiveDialogue = false;
            }
            if (nowTime - launchTime >= 2.5f)
            {
                //下车
                MyObject.Find("YangYi").GetComponent<TakeCar>().GetOff();
                //恢复摄像机平滑系数
                HorizontalSmoothFollow.smoothing = 2.0f;
                if (direction == 1)
                    direction = -1;
                else
                    MyObject.SetObjectActive("Canvas/Dialogue");
                nowTime = 0.0f;
                enabled = false;
            }
        }
    }
}
