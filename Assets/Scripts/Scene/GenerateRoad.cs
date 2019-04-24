using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    [SerializeField] GameObject Road;
    float nowX = -2.00f;
    private void Update()
    {
        Generate();
    }
    private void Generate()
    {
        GameObject newObject = GameObject.Instantiate(Road, new Vector3(nowX, -0.8f, 0), Quaternion.identity);
        newObject.transform.parent = gameObject.transform;
        nowX += 3.64f;
        if (nowX >= 203.0f)
            GetComponent<GenerateRoad>().enabled = false;
    }
}
