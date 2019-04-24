using UnityEngine;

//此脚本用来进行云层的移动
public class CloudFloating : MonoBehaviour
{
    float floatSpeed = 0.15f;        //云层移动的速度               
    void Update()
    {
        this.transform.Translate(-floatSpeed * Time.deltaTime, 0, 0);    //云层的移动  
        if (this.transform.position.x <= 0.0f)                //如果云层超出边界 则，则从头开始移动
            this.transform.position = new Vector3(200.0f, this.transform.position.y, this.transform.position.z);
    }
}
