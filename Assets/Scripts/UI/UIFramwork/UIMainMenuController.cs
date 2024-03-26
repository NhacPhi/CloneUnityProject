using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace UIFramework
{
    public class UIMainMenuController : MonoBehaviour
    {
        [SerializeField] private UISettings defaultUISettings = null;
        //[SerializeField] private FakePlayerData fakePlayerData = null;
        [SerializeField] private Camera cam = null;

        private UIFrame uiFrame;

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

