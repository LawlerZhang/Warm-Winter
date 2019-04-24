using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] Sprite faintSprite;
    public bool isInCarrier = false;
    public void Faint()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = faintSprite;
    }
    public void WakeUp()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<PlayerController>().enabled = true;
    }
}
