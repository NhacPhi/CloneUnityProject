using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

namespace UIFramework
{
    public class StartMainMenuController : WindowController
    {
        public void OnUIShowPopup()
        {
            Signals.Get<ShowGamePopupSignal>().Dispatch(GetPopupData(PopupType.Quit));
        }


        private GamePopupProperties GetPopupData(PopupType type)
        {
            GamePopupProperties popupProperties = null;

            switch(type)
            {
                case PopupType.NewGame:
                    break;
                case PopupType.BackToMenu:
                    break;
                case PopupType.Quit:
                    {
                        popupProperties = new GamePopupProperties("Quit ?", "Are you sure quit?");
                    }
                    break;
                default:
                    Debug.Log("Can find popup smae type");
                    break;

                        
            }

            return popupProperties;
        }
    }
}

