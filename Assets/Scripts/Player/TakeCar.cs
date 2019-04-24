using UnityEngine;
using MyNameSpace;

public class TakeCar : MonoBehaviour
{
    public void GetOn()
    {
        transform.position = new Vector3(6.45f, 0.05f, 0.05f);
        transform.parent = MyObject.Find("PropSet/Taxi").transform;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<PlayerStatus>().isInCarrier = true;
    }
    public void GetOff()
    { 
        transform.parent = null;
        GetComponent<PlayerController>().enabled = true;
        transform.position = new Vector3(transform.position.x, -0.3f, -0.2f);
        GetComponent<Animator>().enabled = true;
        GetComponent<PlayerStatus>().isInCarrier = false;
    }
}
