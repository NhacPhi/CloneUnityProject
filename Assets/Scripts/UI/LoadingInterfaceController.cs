using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject _loadingInterface = default;

    [Header("Listing on")]
    [SerializeField] private BoolEventChannelSO _toggleLoadingScene = default;

    private void OnEnable()
    {
        _toggleLoadingScene.OnEventRaised += ToggleLoadingScene;   
    }

    private void OnDisable()
    {
        _toggleLoadingScene.OnEventRaised -= ToggleLoadingScene;
    }

    private void ToggleLoadingScene(bool state)
    {
        _loadingInterface.SetActive(state);
    }
}
