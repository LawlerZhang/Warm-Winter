using UnityEngine;
using MyNameSpace;

public class FollowTarget : MonoBehaviour
{
    GameObject Target;
    private void FixedUpdate()
    {
        Target = MyPlayer.GetPlayer();
        transform.position = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
    }
}
