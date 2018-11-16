using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private float cameraMousePanSpeed;
    [SerializeField] private float cameraMobilePanSpeed;

    private float cameraPanSpeed;

    private Vector3 touchStart;

    private void Start()
    {
        if (GameManager.instance.IsOnMobile)
        {
            cameraPanSpeed = cameraMobilePanSpeed;
        }
        else
        {
            cameraPanSpeed = cameraMousePanSpeed;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return; //TODO doesn't work for mobile

            Vector3 direction = new Vector2(Input.mousePosition.x - touchStart.x, Input.mousePosition.y - touchStart.y);
            touchStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.position = new Vector2(transform.position.x - direction.x * cameraPanSpeed * Time.deltaTime, transform.position.y- direction.y * cameraPanSpeed * Time.deltaTime);
        }
    }
}