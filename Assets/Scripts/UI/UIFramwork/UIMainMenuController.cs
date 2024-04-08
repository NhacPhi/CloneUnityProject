using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace UIFramework
{
    public class UIMainMenuController : MonoBehaviour
    {
        [SerializeField] private UISettings defaultUISettings = null;
        //[SerializeField] private FakePlayerData fakePlayerData = null;
        //[SerializeField] private Camera cam = null;

        private UIFrame uiFrame;

        private Camera _overlayCamera;
        private void Awake()
        {
            uiFrame = defaultUISettings.CreateUIInstance();
        }
        private void OnEnable()
        {
            Signals.Get<ShowGamePopupSignal>().AddListener(OnShowPopup);
        }

        private void OnDisable()
        {
            Signals.Get<ShowGamePopupSignal>().RemoveListener(OnShowPopup);
        }
        // Start is called before the first frame update
        void Start()
        {
            //_overlayCamera = uiFrame.GetComponent<Transform>().Find("UICamera").GetComponent<Camera>();
            //if (_overlayCamera != null)
            //{
            //    var cameraData = cam.GetUniversalAdditionalCameraData();
            //    cameraData.cameraStack.Add(_overlayCamera);
            //}
            //else
            //{
            //    Debug.Log("Don't find camera UI");
            //}

            uiFrame.OpenWindow(ScreenIds.StartMainMenu);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnShowPopup(GamePopupProperties popupProperites)
        {
            uiFrame.OpenWindow(ScreenIds.ConfirmationPopup, popupProperites);
        }
    }
}

