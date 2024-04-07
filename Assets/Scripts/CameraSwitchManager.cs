using UnityEngine;

public class CameraSwitchManager : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] EnableCamera[] _cameras;
    [SerializeField, Range(0.01f, 1f)] float _lerpTime = 0.8f;

    private void Start()
    {
        _cameras = transform.GetComponentsInChildren<EnableCamera>();
    }

    private void Update()
    {
        HandleCameraSwitch();
    }

    //handles camera movement from current area to next
    private void HandleCameraSwitch()
    {
        foreach (var cam in _cameras)
        {
            //if any of the camera areas have the player in their view, smoothly moves the game camera to the area's position
            //and sets the camera's size to fit the area's contents
            if (cam.playerInView)
            {
                Vector3 _newPosition =
                    new Vector3(cam.transform.position.x, _mainCamera.transform.position.y, cam.transform.position.z - 10);

                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _newPosition, _lerpTime);
                _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, cam.size, _lerpTime);
                _mainCamera.backgroundColor = cam.cameraBackground;
            }
        }
    }
}