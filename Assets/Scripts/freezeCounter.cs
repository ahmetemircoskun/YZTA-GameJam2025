using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FreezeCounterManager : MonoBehaviour
{
    public static FreezeCounterManager Instance;

    private int globalFreezeCount = 0;
    private int sceneFreezeCount = 0;

    [SerializeField] List<string> ignoredScenes = new List<string>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseSceneCount()
    {
        if (IsSceneIgnored()) return;

        sceneFreezeCount++;
    }

    public void CommitSceneCount()
    {
        if (IsSceneIgnored()) return;

        globalFreezeCount += sceneFreezeCount;
        sceneFreezeCount = 0;
    }

    public void ResetSceneCount()
    {
        if (IsSceneIgnored()) return;

        sceneFreezeCount = 0;
    }

    public int GetCurrentDisplayCount()
    {
        return globalFreezeCount + sceneFreezeCount;
    }

    public void ResetAllCounts()
    {
        globalFreezeCount = 0;
        sceneFreezeCount = 0;
    }


    private bool IsSceneIgnored()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        return ignoredScenes.Contains(currentScene);
    }
}
