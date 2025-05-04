using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] AudioClip teleportSound;
    [SerializeField] AudioClip freezingSound;

    GameObject currentPlayer;
    Vector3 initialPosition;
    bool firstSpawnDone = false;

    void Start()
    {
        currentPlayer = GameObject.FindWithTag("Player");

        if (currentPlayer == null && !firstSpawnDone)
        {
            currentPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            currentPlayer.tag = "Player";
            initialPosition = transform.position;
            firstSpawnDone = true;
        }
        else
        {
            initialPosition = currentPlayer.transform.position;
            firstSpawnDone = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (FreezeCounterManager.Instance != null)
            {
                FreezeCounterManager.Instance.ResetSceneCount();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TeleportCurrentPlayerToSpawn();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FreezeCounterManager.Instance != null)
            {
                FreezeCounterManager.Instance.IncreaseSceneCount();
            }

            AudioSource source = currentPlayer.GetComponent<AudioSource>();
            if (source != null && freezingSound != null)
            {
                source.PlayOneShot(freezingSound);
            }

            var oldRb = currentPlayer.GetComponent<Rigidbody2D>();
            var oldCtrl = currentPlayer.GetComponent<characterController>();
            var oldAnimator = currentPlayer.GetComponent<Animator>();

            if (oldRb != null)
            {
                oldRb.linearVelocity = Vector2.zero;
                oldRb.bodyType = RigidbodyType2D.Static;
            }

            if (oldCtrl != null)
            {
                oldCtrl.enabled = false;
            }

            if (oldAnimator != null)
            {
                oldAnimator.speed = 0f;
            }

            var sprite = currentPlayer.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            }

            currentPlayer.tag = "Zemin";

            GameObject newChar = Instantiate(playerPrefab, initialPosition, Quaternion.identity);
            newChar.tag = "Player";
            currentPlayer = newChar;
        }
    }

    public void TeleportCurrentPlayerToSpawn()
    {
        if (currentPlayer != null)
        {
            AudioSource source = currentPlayer.GetComponent<AudioSource>();
            if (source != null && teleportSound != null)
            {
                source.PlayOneShot(teleportSound);
            }

            currentPlayer.transform.position = initialPosition;

            var rb = currentPlayer.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}
