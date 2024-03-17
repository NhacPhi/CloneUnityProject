using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/UI/Fade channel")]
public class FadeChannelSO : DescriptionBaseSO
{
    public UnityAction<bool, float, Color> OnRaisedEvent;

    public void FadeIn(float ducation)
    {
        Fade(true, ducation,Color.clear);
    }

    public void Fadeout(float duration)
    {
        Fade(false, duration,Color.black);
    }

    private void Fade(bool fadeIn, float duration, Color color)
    {
        if(OnRaisedEvent != null)
        {
            OnRaisedEvent.Invoke(this, duration, color);
        }
    }
}
