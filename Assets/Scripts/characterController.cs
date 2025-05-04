using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{
    float speed;
    float moveDirection;
    [SerializeField] float jumpForce;

    bool isGrounded = true;
    bool isJumping = false;

    Rigidbody2D rbody;
    Animator animator;
    SpriteRenderer srenderer;
    Camera cam;

    Vector3 character_position;

    void Start()
    {

        cam = Camera.main;
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        srenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", speed);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", isJumping);
        character_position = transform.position;

        rbody.linearVelocity = new Vector2(speed * moveDirection, rbody.linearVelocityY);

        if (isJumping)
        {
            rbody.linearVelocityY = jumpForce;
            isJumping = false;
        }

    }

    void Update()
    {

        if (isGrounded && (Input.GetKey(KeyCode.W)))
        {
            isJumping = true;
            isGrounded = false;
        }

        else if (isGrounded)
        {
            moveDirection = 0f;
            speed = 0f;

            if (Input.GetKey(KeyCode.D))
            {
                srenderer.flipX = false;
                moveDirection = 1f;
                speed = Input.GetKey(KeyCode.LeftShift) ? 4f : 2f;
            }

            else if (Input.GetKey(KeyCode.A))
            {
                srenderer.flipX = true;
                moveDirection = -1f;
                speed = Input.GetKey(KeyCode.LeftShift) ? 4f : 2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            isGrounded = true;
        }
    }

    void LateUpdate()
    {
        if (cam == null) return;

        Vector3 pos = transform.position;

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Vector3 camPos = cam.transform.position;

        float leftBound = camPos.x - camWidth / 2f;
        float rightBound = camPos.x + camWidth / 2f;
        float bottomBound = camPos.y - camHeight / 2f;
        float topBound = camPos.y + camHeight / 2f;

        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);

        transform.position = pos;
    }


}
