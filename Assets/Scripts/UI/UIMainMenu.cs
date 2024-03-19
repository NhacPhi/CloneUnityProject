using UnityEngine;
using UnityEngine.Events;

public class UIMainMenu : MonoBehaviour
{
    public UnityAction ExitButtonAction;

    public void ExitButton()
    {
        ExitButtonAction.Invoke();
    }
}
