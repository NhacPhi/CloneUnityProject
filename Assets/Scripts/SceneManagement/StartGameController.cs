using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private GameSceneSO _locationsToLoad;

    [Header("Listening to")]
    [SerializeField] private VoidEventChannelSO _onNewGameButton;

    [Header("Broading on")]
    [SerializeField] private LoadEventChannelSO _loadLocation;

    private void OnEnable()
    {
        _onNewGameButton.OnEventRaised += OnStartNewGame;
    }
    private void OnDisable()
    {
        _onNewGameButton.OnEventRaised -= OnStartNewGame;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnStartNewGame ()
    {
        _loadLocation.RaiseEvent(_locationsToLoad);
    }
}
