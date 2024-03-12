using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneLoader : MonoBehaviour
{
    [Header("Listening to")]
    [SerializeField] private LoadEventChannelSO _loadMenu = default;

    private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;

    //Parameters coming from scene loaidng request
    private bool _isLoading = false; //To prevent a new loading request while already loading a new scene
    private GameSceneSO _sceneToLoad;


    private void OnEnable()
    {
        _loadMenu.OnLoadingRequested += LoadMenu;
    }

    private void OnDisable()
    {
        _loadMenu.OnLoadingRequested -= LoadMenu;
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


        //StartCoroutine(UnloadPreviousScene());
        LoadNewScene();
    }


    private void LoadNewScene()
    {
        _loadingOperationHandle = _sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
    }
}
