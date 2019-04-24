using UnityEngine;

public class PopMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void Click()
    {
        menu.SetActive(true);
    }
}
