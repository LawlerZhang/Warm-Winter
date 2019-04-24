using UnityEngine;
using MyNameSpace;

public class GirlBehaviour : MonoBehaviour
{
    float walkSpeed = 2.0f;    //走路速度
    int walkDirection = -1;    //1 代表向右,-1 代表向左
    int actionStatus = 0;
    float nowTime = 0.0f;
    Animator myAnimator;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.localScale = new Vector3(walkDirection * 0.22f, 0.2f, 1);
        if (actionStatus == 0) RescueDog();
        else if (actionStatus == 1) MoveToFather();
        else if (actionStatus == 2) MoveToRoom();
    }
    //解救小狗
    void RescueDog()
    {
        GameObject _Faint = MyObject.Find("StoryTriggerSet/Faint");
        if (transform.position.x - _Faint.transform.position.x >= 0.2f)
        {
            myAnimator.SetInteger("Status", 1);
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            myAnimator.SetInteger("Status", 0);
            AppearInRoom();
            MyObject.Find("NPC/Puppy").transform.position = new Vector3(235.7f, 1.86f, -0.2f);
            MyObject.Find("NPC/Puppy").GetComponent<PlayerStatus>().WakeUp();
            MyObject.Find("NPC/Puppy").transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().FixScreen(new Vector3(235.6f, 2, -10));
            MyObject.SetObjectActive("Canvas/Aside");
            MyObject.Find("AudioSet/BGM").GetComponent<BGMManager>().PlayBGM("GirlHome");
            actionStatus = -1;
        }
    }
    //
    void MoveToFather()
    {
        if (transform.position.y == 2.0f)
        {
            if (transform.position.x <= 239.5f)
            {
                myAnimator.SetInteger("Status", 1);
                walkDirection = 1;
            }
            else if (nowTime <= 2.0f)
            {
                nowTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                transform.position = new Vector3(239.5f, -0.25f, -0.2f);
                GetComponent<SpriteRenderer>().enabled = true;
                nowTime = 0.0f;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y == -0.25f)
        {
            if (transform.position.x >= 235.5)
                walkDirection = -1;
            else
            {
                myAnimator.SetInteger("Status", 0);
                walkDirection = 1;
                MyObject.SetObjectActive("Canvas/Dialogue");
                actionStatus = -1;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
    }
    //
    void MoveToRoom()
    {
        if (transform.position.y == -0.25f)
        {
            if (transform.position.x <= 239.5f)
            {
                myAnimator.SetInteger("Status", 1);
                walkDirection = 1;
            }
            else if (nowTime <= 2.0f)
            {
                nowTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                transform.position = new Vector3(239.5f, 2.0f, -0.2f);
                GetComponent<SpriteRenderer>().enabled = true;
                nowTime = 0.0f;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y == 2.0f)
        {
            if (transform.position.x >= 234.5)
                walkDirection = -1;
            else
            {
                myAnimator.SetInteger("Status", 0);
                walkDirection = 1;
                actionStatus = -1;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
    }
    public void AppearInRoom()
    {
        transform.position = new Vector3(235, 2, -0.2f);
        walkDirection = 1;
    }
    public void SetStatus(int status)
    {
        if (status >= 0 && status <= 10)
            actionStatus = status;
    }
}
