using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/ Bool event channel", fileName ="BoolEventChannel")]
public class BoolEventChannelSO : DescriptionBaseSO
{
    public UnityAction<bool> OnEventRaised;

    public void RaiseEvent(bool value)
    {
        if(OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
