using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void ChangeScene()
    {
        if (sceneName == "0")
        {
            if (FreezeCounterManager.Instance != null)
            {
                FreezeCounterManager.Instance.ResetAllCounts();
            }
        }
        SceneManager.LoadScene(sceneName);
    }
}
