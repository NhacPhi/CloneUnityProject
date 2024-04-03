using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineFreeLook freeLookVCam;

    public InputReader inputReader;

    [SerializeField] private TransformAnchor _cameraTransformAnchor = default;
    [SerializeField][Range(.5f, 3f)] private float _speedMultiplier = 1f;
    private void OnEnable()
    {
        _cameraTransformAnchor.Provide(mainCamera.transform);
        inputReader.CameraEvent += OnCameraMove;
    }

    private void OnDisable()
    {
        _cameraTransformAnchor.Unset();
        inputReader.CameraEvent -= OnCameraMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
    {
        Debug.Log("cameraMovement : " + cameraMovement);
        float deviceMultiplier = isDeviceMouse ? 0.02f : Time.deltaTime;

        freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * deviceMultiplier * _speedMultiplier;
        freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * deviceMultiplier * _speedMultiplier;
    }
}
