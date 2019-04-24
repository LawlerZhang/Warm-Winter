using UnityEngine;
using MyNameSpace;

public class FatherBehaviour : MonoBehaviour
{
    float walkSpeed = 1.5f;    //走路速度
    int walkDirection = -1;    //1 代表向右,-1 代表向左
    int actionStatus = -1;
    float nowTime = 0.0f;
    Animator myAnimator;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.localScale = new Vector3(walkDirection * 0.8f, 0.8f, 1);
        if (actionStatus == 0) MoveToSleep();
        else if (actionStatus == 1) GoDownstairs();
    }
    //去睡觉
    void MoveToSleep()
    {
        if (transform.position.y == -0.1f)
        {
            if (transform.position.x < 239.75f)
            {
                walkDirection = 1;
                myAnimator.SetInteger("Status", 1);
            }
            else if (nowTime <= 2.0f)
            {
                nowTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                nowTime = 0.0f;
                GetComponent<SpriteRenderer>().enabled = true;
                transform.position = new Vector3(239.75f, 2.15f, -0.2f);
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y == 2.15f)
        {
            if (transform.position.x > 238.2f)
                walkDirection = -1;
            else
            {
                myAnimator.SetInteger("Status", 0);
                walkDirection = 1;
                actionStatus = -1;
                gameObject.SetActive(false);
                MyObject.Find("GirlHome/FatherBed").GetComponent<FurnitureBehaviour>().ChangeSprite(1);
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
    }
    //下楼
    void GoDownstairs()
    {
        if (transform.position.y == 2.15f)
        {
            if (transform.position.x < 239.75f)
            {
                walkDirection = 1;
                myAnimator.SetInteger("Status", 1);
            }
            else if (nowTime <= 2.0f)
            {
                nowTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                nowTime = 0.0f;
                GetComponent<SpriteRenderer>().enabled = true;
                transform.position = new Vector3(239.75f, -0.1f, -0.2f);
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y == -0.1f)
        {
            if (transform.position.x > 236.4f)
                walkDirection = -1;
            else
            {
                myAnimator.SetInteger("Status", 0);
                MyObject.SetObjectActive("Canvas/Dialogue");
                Invoke("DiscardPuppy", 2.0f);
                MyObject.Find("AudioSet/BGM").GetComponent<BGMManager>().PlayBGM("GuDeng");
                actionStatus = -1;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
    }
    //设置状态
    public void SetStatus(int status)
    {
        if (status >= 0 && status <= 10)
            actionStatus = status;
    }
    void DiscardPuppy()
    {
        MyObject.SetObjectActive("Canvas/Aside");
        MyObject.Find("NPC/Puppy").transform.position = new Vector3(189.0f, -0.45f, -0.2f);
        MyObject.Find("NPC/Puppy").GetComponent<PlayerController>().ClearTarget();
        MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().SetTarget("NPC/Puppy");
        MyObject.SetObjectActive("NPC/Stranger");
    }
}
