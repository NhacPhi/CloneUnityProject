using UnityEngine;
using UnityEngine.Events;

public class UIGenericButton : MonoBehaviour
{
    public UnityAction Clicked = default;

    public void Click()
    {
        if(Clicked != null) 
        {
            Clicked.Invoke();
        }
    }
}
