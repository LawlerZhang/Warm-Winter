using UnityEngine;

public class ClickToClose : MonoBehaviour
{
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            gameObject.SetActive(false);
    }
}
