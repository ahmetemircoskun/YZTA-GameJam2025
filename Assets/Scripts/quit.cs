using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Oyun kapatıldı");
    }
}
