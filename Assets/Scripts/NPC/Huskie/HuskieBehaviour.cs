using UnityEngine;
using MyNameSpace;

public class HuskieBehaviour : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float terminalX;
    Animator myAnimator;
    int actionStatus = -1;
    private void Awake()
    {
        myAnimator = GameObject.Find("Huskie").GetComponent<Animator>();
    }
    private void Update()
    {
        if (actionStatus == 0) RunToGrasses();
        if (actionStatus == 1) RunAway();
    }
    void RunToGrasses()        //跑向灌木丛
    {
        if (transform.position.x < terminalX)
        {
            myAnimator.SetInteger("Status", 1);
            transform.Translate(runSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position = new Vector3(27.25f, -0.08f, -0.05f);
            myAnimator.SetInteger("Status", 0);
            actionStatus = -1;
        }
    }
    void RunAway()
    {
        myAnimator.SetInteger("Status", 1);
        transform.Translate(runSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x > 46.0f)
        {
            actionStatus = -1;
            MyObject.SetObjectActive("Canvas/Aside");
            gameObject.SetActive(false);
        }
    }
    //
    public void SetStatus(int status)
    {
        actionStatus = status;
    }
}
