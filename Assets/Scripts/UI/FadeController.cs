using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image _imageConpoment;

    [Header("Listing on")]
    [SerializeField] private FadeChannelSO _fadeChannel;

    private void OnEnable()
    {
        _fadeChannel.OnRaisedEvent += InitiateFade;
    }

    private void OnDisable()
    {
        _fadeChannel.OnRaisedEvent -= InitiateFade;
    }

    private void InitiateFade(bool fadeIn, float duration, Color desiredColer)
    {
        _imageConpoment.DOBlendableColor(desiredColer, duration);
    }
}
