using UnityEngine;
using MyNameSpace;

public class DreamYangBehaviour : MonoBehaviour
{
    float walkSpeed = 2.0f;    //走路速度
    int walkDirection = 1;    //1 代表向右,-1 代表向左
    int actionStatus = -1;
    Animator myAnimator;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (actionStatus == 0) DriveHuskie();
    }
    void DriveHuskie()
    {
        if (transform.position.x < 13.0f)
        {
            walkDirection = 1;
            myAnimator.SetInteger("Status", 1);
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            Invoke("Awaken", 3.0f);
        }
    }
    public void SetStatus(int status)
    {
        actionStatus = status;
    }
    void Awaken()
    {
        MyObject.SetObjectActive("Canvas/Aside");
        MyPlayer.ResetPlayer();
        MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().SetTarget(MyPlayer.GetPlayer());
        MyObject.Find("Camera").transform.position = new Vector3(220, 2, -10);
        MyObject.Find("Camera").GetComponent<HorizontalSmoothFollow>().FixScreen();
        MyObject.Find("NPC/Huskie").transform.position = new Vector3(39.5f, -0.3f, -0.2f);
        MyObject.Find("NPC/Huskie").GetComponent<PlayerStatus>().WakeUp();
        MyObject.Find("NPC/Huskie").GetComponent<PlayerController>().enabled = false;
        MyObject.Find("NPC/Huskie").GetComponent<Animator>().SetInteger("Status", 0);
        MyObject.Find("NPC/Huskie").transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        gameObject.SetActive(false);
        Invoke("ActiveDialogue", 3.0f);
    }
    void ActiveDialogue()
    {
        MyObject.SetObjectActive("Canvas/Dialogue");
    }
}
