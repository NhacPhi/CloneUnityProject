using UnityEngine;
using Utils;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

namespace UIFramework
{
    public enum PopupType
    {
        Quit,
        NewGame,
        BackToMenu
    }
    public class ShowGamePopupSignal : ASignal<GamePopupProperties> { }
    public class GamePopupController : WindowController<GamePopupProperties>
    {
        [SerializeField] public TextMeshProUGUI titleLabel;
        [SerializeField] public TextMeshProUGUI messageLable;
        [SerializeField] public TextMeshProUGUI confirmButtonLable;
        [SerializeField] public TextMeshProUGUI cancelButtonLalble;

        protected override void OnPropertiesSet()
        {
            titleLabel.text = Properties.Title;
            messageLable.text = Properties.Message;
            confirmButtonLable.text = Properties.ConfirmButtonText;
            cancelButtonLalble.text = Properties.CancelButtonText;
        }

        public void OnUICancel()
        {
            UI_Close();
        }

        public void OnUIConfirm()
        {
            UI_Close();
            if (Properties.OnConfirmAction != null)
            {
                Properties.OnConfirmAction.Invoke();
            }
        }
    }

    [System.Serializable]
    public class GamePopupProperties : WindowProperties
    {
        public readonly string Title;
        public readonly string Message;
        public readonly string ConfirmButtonText;
        public readonly string CancelButtonText;
        public readonly UnityAction OnCannelAction;
        public readonly UnityAction OnConfirmAction;

        public GamePopupProperties(string tille, string message, string confirmButtonText = "Confirm",string cancelButtonText = "Cancel"
            , UnityAction confirmAction = null, UnityAction cancelAction = null)
        {
            Title = tille;
            Message = message;
            ConfirmButtonText = confirmButtonText;
            CancelButtonText = cancelButtonText;
            OnConfirmAction = confirmAction;
            OnCannelAction = cancelAction;
        }

    }
}

