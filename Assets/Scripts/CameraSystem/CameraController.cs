using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private Camera _overlayCamera;
    // Start is called before the first frame update
    void Start()
    { 
        _overlayCamera = _canvas.GetComponent<Transform>().Find("UICamera").GetComponent<Camera>();
        if(_overlayCamera != null )
        {
            var cameraData = Camera.main.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(_overlayCamera);
        }
        else
        {
            Debug.Log("Don't find camera UI");
        }

    }

}
