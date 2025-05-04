using UnityEngine;
using TMPro;

public class PuanYazici : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puanText;

    void Start()
    {
        if (FreezeCounterManager.Instance != null && puanText != null)
        {
            int puan = FreezeCounterManager.Instance.GetCurrentDisplayCount();
            puanText.text = $"Bravo! {puan} tecrübe puanıyla ilk kapıyı tamamladın.";
        }
    }
}
