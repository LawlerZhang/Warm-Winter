using UnityEngine;
using MyNameSpace;

public class ThiefBehaviour : MonoBehaviour
{
    float walkSpeed = 1.5f;    //走路速度
    int walkDirection = 1;    //1 代表向右,-1 代表向左
    int actionStatus = -1;
    Animator myAnimator;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.localScale = new Vector3(walkDirection * 0.8f, 0.8f, 1);
        if (actionStatus == 0) Flee();
    }
    //逃跑
    void Flee()
    {
        if (transform.position.x < 237.25)
        {
            myAnimator.SetInteger("Status", 1);
            walkDirection = 1;
        }
        else
        {
            actionStatus = -1;
            MyObject.Find("GirlHome/FatherBed").GetComponent<FurnitureBehaviour>().ChangeSprite(0);
            MyObject.SetObjectActive("NPC/Father");
            Invoke("AlarmFather", 3.0f);
            MyObject.SetObjectActive("Canvas/Dialogue");
            gameObject.SetActive(false);
        }
        transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
    }
    //设置状态
    public void SetStatus(int status)
    {
        if (status >= 0 && status <= 10)
            actionStatus = status;
    }
    //惊动爸爸
    void AlarmFather()
    {
        MyObject.Find("NPC/Father").GetComponent<FatherBehaviour>().SetStatus(1);
    }
}
