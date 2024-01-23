using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2;

    private Vector3 lastMousePosition;

    public float zoomSpeed = 1;
    public float minOrthoSize = 5;
    public float maxOrthoSize = 20;

    void Update()
    {
        // 마우스 드래그를 이용한 카메라 이동
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Translate(-delta.x * dragSpeed, -delta.y * dragSpeed, 0);
            lastMousePosition = Input.mousePosition;
        }

        // 마우스 휠을 이용한 카메라 줌
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
    }
}
