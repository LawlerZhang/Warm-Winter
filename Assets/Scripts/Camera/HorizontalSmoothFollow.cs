using UnityEngine;
using MyNameSpace;

//用于水平方向的平滑跟随
public class HorizontalSmoothFollow : MonoBehaviour
{
    public static float smoothing;    //平滑系数
    [SerializeField] GameObject target;  //角色
    float deltaX;   //x轴方向位置差
    private void Awake()
    {
        smoothing = 2.0f;
        deltaX = transform.position.x - target.transform.position.x;
    }
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x + deltaX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
        transform.position = new Vector3(target.transform.position.x + 1, 2, -10);
    }
    public void SetTarget(string targetName)
    {
        this.target = MyObject.Find(targetName);
        transform.position = new Vector3(target.transform.position.x + 1, 2, -10);
        enabled = true;
    }
    public void FixScreen(Vector3 position)
    {
        transform.position = position;
        enabled = false;
    }
    public void FixScreen()
    {
        enabled = false;
    } 
}
