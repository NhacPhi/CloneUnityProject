﻿using UnityEngine;
using System.Collections.Generic;

namespace UIFramework {

    public class WindowParaLayer : MonoBehaviour {
        [SerializeField] 
        private GameObject darkenBgObject = null;

        private List<GameObject> containedScreens = new List<GameObject>();
        
        public void AddScreen(Transform screenRectTransform) {
            screenRectTransform.SetParent(transform, false);
            containedScreens.Add(screenRectTransform.gameObject);
        }

        public void RefreshDarken() {
            for (int i = 0; i < containedScreens.Count; i++) {
                if (containedScreens[i] != null) {
                    if (containedScreens[i].activeSelf) {
                        darkenBgObject.SetActive(true);
                        return;
                    }
                }
            }

            darkenBgObject.SetActive(false);
        }

        public void DarkenBG() {
            darkenBgObject.SetActive(true);
            darkenBgObject.transform.SetAsLastSibling();
        }
    }
}
