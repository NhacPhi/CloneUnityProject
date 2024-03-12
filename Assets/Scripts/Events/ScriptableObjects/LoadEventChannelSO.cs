using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/ Load Event Channel", fileName = "LoadEventChannel")]
public class LoadEventChannelSO : DescriptionBaseSO
{
    public UnityAction<GameSceneSO, bool, bool> OnLoadingRequested;

    public void RaiseEvent(GameSceneSO locationToLoad, bool showLoadingScene = false, bool fadeScene = false)
    {
        if(OnLoadingRequested != null)
        {
            OnLoadingRequested.Invoke(locationToLoad, showLoadingScene, fadeScene);
        }
        else
        {
            Debug.Log("A scene loading was requested, but nobody picked it up" +
                "Check why there is no SceneLoader already present" +
                "and make sure it's listening on this Load Event channel");
        }
    }
}
