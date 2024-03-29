using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

namespace UIFramework
{
    public class StartMainMenuController : WindowController
    {
        [Header("Broadcasting on")]
        [SerializeField] private VoidEventChannelSO _startNewGameEvent;
        public void OnUIShowPopup()
        {
            Signals.Get<ShowGamePopupSignal>().Dispatch(GetPopupData(PopupType.Quit));
        }

        public void OnNewGame()
        {
            Signals.Get<ShowGamePopupSignal>().Dispatch(GetPopupData(PopupType.NewGame));
            //_startNewGameEvent.RaiseEvent();
        }

        private GamePopupProperties GetPopupData(PopupType type)
        {
            GamePopupProperties popupProperties = null;

            switch(type)
            {
                case PopupType.NewGame:
                    {
                        popupProperties = new GamePopupProperties("NewGame ?", "Are you sure create new game?", "Confirm", "Cacnel", _startNewGameEvent.OnEventRaised);
                    }
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

