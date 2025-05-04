using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float switchInterval = 3f;

    private float direction = 1f;
    private float timer = 0f;

    void Update()
    {
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            ReverseDirection();
        }
    }

    void ReverseDirection()
    {
        direction *= -1f;
        timer = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Zemin"))
        {
            ReverseDirection();
        }
    }
}
