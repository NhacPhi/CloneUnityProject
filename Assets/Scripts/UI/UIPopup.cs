using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public enum PopupButtonType
{
    Confirm,
    Cannel,
    Close,
    DoNothing
}

public enum PopupType
{
    Quit,
    NewGame,
    BackToMenu
}

public class UIPopup : MonoBehaviour
{
    [SerializeField] private UIGenericButton _popupButton01 = default;
    [SerializeField] private UIGenericButton _popupButton02 = default;

    private PopupType _actualType;

    public event UnityAction<bool> ConfirmationResponseAction;
    public event UnityAction ClosePopupAction;

    private void OnDisable()
    {
        _popupButton01.Clicked -= ConfirmButtonClicked;
        _popupButton02.Clicked -= CancelButtonClicked;
    }

    public void SetPopup(PopupType popupType)
    {
        _actualType = popupType;
        bool isConfirmation = false;
        bool hasExitButton = false;

        switch (_actualType)
        {
            case PopupType.Quit:
                isConfirmation = true;
                //_popupButton01.SetButton(tableEntryReferenceConfirm, true);
                //_popupButton02.SetButton(tableEntryReferenceCancel, false);
                hasExitButton = false;
                break;
        }

        if (isConfirmation) // needs two button : Is a decision 
        {
            //_popupButton1.gameObject.SetActive(true);
            //_popupButton2.gameObject.SetActive(true);

            _popupButton02.Clicked += CancelButtonClicked;
            _popupButton01.Clicked += ConfirmButtonClicked;
        }
    }

    private void ConfirmButtonClicked()
    {
        ConfirmationResponseAction.Invoke(true);
    }
    private void CancelButtonClicked()
    {
        ConfirmationResponseAction(false);
    }
}
