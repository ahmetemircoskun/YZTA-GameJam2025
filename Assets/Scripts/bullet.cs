using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        if (rbody != null)
            rbody.linearVelocity = -transform.right * speed;

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSwitcher switcher = FindAnyObjectByType<PlayerSwitcher>();
            if (switcher != null)
            {
                switcher.TeleportCurrentPlayerToSpawn();
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Zemin"))
        {
            Destroy(gameObject);
        }
    }
}
