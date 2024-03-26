using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace UIFramework
{
    public class ShowGamePopupSignal : ASignal<GamePopupProperties> { }
    public class GamePopupController : WindowController<GamePopupProperties>
    {
        public void OnUICancel()
        {
            UI_Close();
        }

        public void OnUIConfirm()
        {
            UI_Close();
        }
    }

    [System.Serializable]
    public class GamePopupProperties : WindowProperties
    {

    }
}

