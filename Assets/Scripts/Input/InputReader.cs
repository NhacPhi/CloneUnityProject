using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : DescriptionBaseSO, GameInput.IGameplayActions,GameInput.IMainMenuActions
{
    // GamePlay
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction<Vector2, bool> CameraEvent = delegate { };

    // Menus
    public event UnityAction MenuMouseMoveEvent = delegate { };

    // Shared between menus and dialogues
    public event UnityAction MoveSelectionEvent = delegate { };
    private GameInput _gameInput;
    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.MainMenu.SetCallbacks(this);
        }
    }
    private bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";

    public bool LeftMouseDown() => Mouse.current.leftButton.isPressed;

    private void OnDisable()
    {
        DisableAllInput();
    }
    public void DisableAllInput()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.MainMenu.Disable();
    }

    public void EnableMainMenu()
    {
        _gameInput.MainMenu.Enable();
        _gameInput.Gameplay.Disable();
    }

    public void EnableGamePlay()
    {
        _gameInput.MainMenu.Disable();
        _gameInput.Gameplay.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        CameraEvent.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            MenuMouseMoveEvent.Invoke();
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            MoveSelectionEvent.Invoke();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {

    }
}