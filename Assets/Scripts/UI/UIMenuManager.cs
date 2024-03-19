using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private UIPopup _popupPanel = default;
    [SerializeField] private UIMainMenu _mainMenuPanel = default;


    private void Start()
    {
        SetMenuScene();
    }

    void SetMenuScene()
    {
        _mainMenuPanel.ExitButtonAction += ShowExitConfirmationPopup;
    }


    public void ShowExitConfirmationPopup()
    {
        _popupPanel.ConfirmationResponseAction += HideExitConfirmationPopup;
        _popupPanel.gameObject.SetActive(true);
        _popupPanel.SetPopup(PopupType.Quit);



    }

    void HideExitConfirmationPopup(bool quitConfirmed)
    {
        _popupPanel.ConfirmationResponseAction -= HideExitConfirmationPopup;
        _popupPanel.gameObject.SetActive(false);
        if (quitConfirmed)
        {
            Application.Quit();
        }
        //_mainMenuPanel.SetMenuScreen(_hasSaveData);


    }

    private void OnDestroy()
    {
        _popupPanel.ConfirmationResponseAction -= HideExitConfirmationPopup;
    }
}
