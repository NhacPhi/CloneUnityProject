using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : DescriptionBaseSO, GameInput.IGameplayActions, GameInput.IMainMenuActions
{
    // GamePlay
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction<Vector2, bool> CameraEvent = delegate { };

    // Menus
    public event UnityAction MenuMouseMoveEvent = delegate { };

    // Shared between menus and dialogues
    public event UnityAction MoveSelectionEvent = delegate { };

    public event UnityAction StartedRunning = delegate { };
    public event UnityAction StoppedRunning = delegate { };

    public event UnityAction JumpEvent = delegate { };
    public event UnityAction JumpCanceledEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction AttackCancelEvent = delegate { };
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

    public void OnRun(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                StartedRunning.Invoke();
                break;
            case InputActionPhase.Canceled:
                StoppedRunning.Invoke();
                break;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            JumpEvent.Invoke();

        if (context.phase == InputActionPhase.Canceled)
            JumpCanceledEvent.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            AttackEvent.Invoke();

        if (context.phase == InputActionPhase.Canceled)
            AttackCancelEvent.Invoke();
    }
}