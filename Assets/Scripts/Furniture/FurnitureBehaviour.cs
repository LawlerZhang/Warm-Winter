using UnityEngine;

public class FurnitureBehaviour : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    public void ChangeSprite(int num)
    {
        if (num >= 0 && num <= sprites.Length - 1)
            GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
}
