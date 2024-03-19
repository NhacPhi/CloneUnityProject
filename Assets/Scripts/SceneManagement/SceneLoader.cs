using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages the scene loalding and unloading
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameSceneSO _gameplayScene = default;

    [Header("Listening to")]
    [SerializeField] private LoadEventChannelSO _loadMenu = default;
    [SerializeField] private LoadEventChannelSO _loadLocation = default;

    [Header("Broadcasting on")]
    [SerializeField] private BoolEventChannelSO _toggleLoadingScene;
    [SerializeField] private FadeChannelSO _fadeRequestChannel = default;

    private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;

    //Parameters coming from scene loaidng request
    private bool _isLoading = false; //To prevent a new loading request while already loading a new scene
    private GameSceneSO _sceneToLoad;
    private bool _showLoadingScreen;

    private float _fadeDuration = 0.5f;

    private void OnEnable()
    {
        _loadMenu.OnLoadingRequested += LoadMenu;
        _loadLocation.OnLoadingRequested += LoadLocation;
    }

    private void OnDisable()
    {
        _loadMenu.OnLoadingRequested -= LoadMenu;
        _loadLocation.OnLoadingRequested -= LoadLocation;
    }


    /// <summary>
    /// Prepares to load the main menu scene, first removing the Gameplay scene in case the game is coming back from gameplay to menus.
    /// </summary>
    private void LoadMenu(GameSceneSO menuToLoad, bool showLoadingScreen, bool fadeScreen)
    {
        //Prevent a double-loading, for situations where the player falls in two Exit colliders in one frame
        if (_isLoading)
            return;

        _sceneToLoad = menuToLoad;
        _showLoadingScreen = showLoadingScreen;

        //StartCoroutine(UnloadPreviousScene());
        StartCoroutine(UnLoadPreviousScene());
    }


    private void LoadNewScene()
    {
        if(_showLoadingScreen)
        {
            _toggleLoadingScene.RaiseEvent(true);
        }

        _loadingOperationHandle = _sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);

        _loadingOperationHandle.Completed += OnNewSceneLoaded;
    }

    /// <summary>
    /// This is function loads the location scene passed as array parameter
    /// </summary>
    private void LoadLocation(GameSceneSO locationToLoad, bool showLoadingScene, bool fadeScene)
    {

    }

    private IEnumerator UnLoadPreviousScene()
    {
        _fadeRequestChannel.Fadeout(_fadeDuration);

        yield return new WaitForSeconds(_fadeDuration);

        LoadNewScene();
    }

    private void OnNewSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if(_showLoadingScreen)
        {
            _toggleLoadingScene.RaiseEvent(false);
        }

        _fadeRequestChannel.FadeIn(_fadeDuration);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
