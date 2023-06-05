using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;
    public Vector3 cameraDefaultPosition;
    
    public static CameraController Instance;
    private Transform cameraTransform;
    private Vector3 lastMousePosition;
    private void Awake()
    {
        Instance = this;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            float rotationY = mouseDelta.x * sensitivity;
            cameraTransform.RotateAround(transform.position, transform.up, rotationY);
            cameraTransform.LookAt(transform);
            lastMousePosition = Input.mousePosition;
        }
        else
        {
            lastMousePosition = Input.mousePosition;
        }
    }

    public void SetTarget(float newTargetXPosition)
    {
        var thisPosition = transform.position;
        Vector3 position = new Vector3(newTargetXPosition, thisPosition.y, thisPosition.z);
        transform.position = position;
    }
}
