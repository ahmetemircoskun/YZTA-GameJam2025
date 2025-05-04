using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2f;
    public float height = 3f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.PingPong(Time.time * speed, height);
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
