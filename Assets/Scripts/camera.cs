using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraSizeController : MonoBehaviour
{
    [SerializeField] float targetWidth;  

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        cam.orthographicSize = targetWidth / screenRatio / 2f;
    }
}
