using UnityEngine;
//角色控制器
public class PlayerController : MonoBehaviour
{
    public static bool canControl = true;
    [SerializeField] float walkSpeed;
    [SerializeField] float threshold;  //能触发运动的阈值
    Animator myAnimator;
    float clickX;  //当前点击屏幕位置的世界坐标的x轴分量
    float targetX; //要移动到的目标位置
    int direction = 1;  //移动方向
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        targetX = transform.position.x;
    }
    private void OnEnable()
    {
        targetX = transform.position.x;
    }
    private void Update()
    {
        if (canControl)
            ClickToMove();
        else
            myAnimator.SetInteger("Status", 0);
    }
    void ClickToMove()
    {
        transform.localScale = new Vector3(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        if (Input.GetMouseButton(0))
        {
            clickX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            //此if-else用于改变人物方向
            if (transform.position.x - clickX > threshold)
            {
                targetX = clickX;
                direction = -1;
            }
            else if (transform.position.x - clickX < -threshold)
            {
                targetX = clickX;
                direction = 1;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            targetX = transform.position.x;
        }
        if (Mathf.Abs(transform.position.x - targetX) >= 0.1f)
        {
            myAnimator.SetInteger("Status", 1);
            transform.Translate(direction * walkSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            myAnimator.SetInteger("Status", 0);
        }
    }
    public void ClearTarget()
    {
        targetX = transform.position.x;
    }
    public void SetDirection(int direction)
    {
        if (direction != 1 && direction != -1)
            return;
        this.direction = direction;
    }
}
