using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    [SerializeField] float nowTimeScale;
    private void Awake()
    {
        nowTimeScale = Time.timeScale;
    }
    private void Update()
    {
        Time.timeScale = nowTimeScale;
    }
}
