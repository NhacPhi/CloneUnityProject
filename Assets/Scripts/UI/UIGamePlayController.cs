using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace UIFramework
{
    public class UIGamePlayController : MonoBehaviour
    {
        [SerializeField] private UISettings defaultUISettings = null;

        private Camera _overlayCamera;

        private UIFrame uiFrame;
        private void Awake()
        {
            uiFrame = defaultUISettings.CreateUIInstance();
        }
        // Start is called before the first frame update
        void Start()
        {
            //_overlayCamera = uiFrame.GetComponent<Transform>().Find("UICamera").GetComponent<Camera>();
            //if (_overlayCamera != null)
            //{
            //    var cameraData = Camera.main.GetUniversalAdditionalCameraData();
            //    cameraData.cameraStack.Add(_overlayCamera);
            //}
            //else
            //{
            //    Debug.Log("Don't find camera UI");
            //}
            // Show GamePlayUI
            uiFrame.OpenWindow(ScreenIds.GamePlayUI);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


