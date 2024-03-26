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
            Signals.Get<ShowGamePopupSignal>().Dispatch(new GamePopupProperties());
        }
    }
}

