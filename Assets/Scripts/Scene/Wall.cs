using UnityEngine;
using MyNameSpace;

public class Wall : MonoBehaviour
{
    [SerializeField] int direction;
    private void Update()
    {
        if (MySpace.IsInArea2D(MyPlayer.GetPlayer(), gameObject, 2.0f))
        {
            if ((MyPlayer.GetPlayer().transform.position.x - transform.position.x) * direction >= 0.0f)
            {
                MyPlayer.GetPlayer().transform.position = new Vector3(transform.position.x,
                MyPlayer.GetPlayer().transform.position.y, MyPlayer.GetPlayer().transform.position.z);
            }
        }
    }
}
