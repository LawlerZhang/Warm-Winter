using UnityEngine;
using MyNameSpace;

public class Boundary : MonoBehaviour
{
    GameObject MainCamera;
    [SerializeField] int direction;
    private void Awake()
    {
        MainCamera = MyObject.Find("Camera");
    }
    private void Update()
    {
        float distance = (MainCamera.transform.position.x - transform.position.x) * direction;
        if (distance >= 0.0f && distance <= 5.0f)
        {
            MainCamera.transform.position = new Vector3(transform.position.x, 2, -10);
            MainCamera.GetComponent<HorizontalSmoothFollow>().FixScreen();
        }
        distance = (MyPlayer.GetPlayer().transform.position.x - transform.position.x) * direction;
        if (distance < -2.5f && distance >= -5.0f)
            MainCamera.GetComponent<HorizontalSmoothFollow>().enabled = true;
    }
}
