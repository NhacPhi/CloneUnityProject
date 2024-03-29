using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework
{
    public class UIGamePlayController : MonoBehaviour
    {
        [SerializeField] private UISettings defaultUISettings = null;


        private UIFrame uiFrame;
        private void Awake()
        {
            uiFrame = defaultUISettings.CreateUIInstance();
        }
        // Start is called before the first frame update
        void Start()
        {
            // Show MainMenu
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


