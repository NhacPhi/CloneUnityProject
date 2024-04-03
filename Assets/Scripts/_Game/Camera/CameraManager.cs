using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineFreeLook freeLookVCam;

    [SerializeField] private TransformAnchor _cameraTransformAnchor = default;

    private void OnEnable()
    {
        _cameraTransformAnchor.Provide(mainCamera.transform);
    }

    private void OnDisable()
    {
        _cameraTransformAnchor.Unset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
