using UnityEngine;
using TMPro;

public class FreezeCounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;

    void Update()
    {
        if (FreezeCounterManager.Instance != null)
        {
            counterText.text = "" + FreezeCounterManager.Instance.GetCurrentDisplayCount();
        }
    }
}
