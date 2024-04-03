using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : DescriptionBaseSO, GameInput.IGameplayActions
{
    // GamePlay
    public event UnityAction<Vector2> MoveEvent = delegate { };

    private GameInput _gameInput;
    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
            _gameInput.Gameplay.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        DisableAllInput();
    }
    public void DisableAllInput()
    {
        _gameInput.Gameplay.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("ABC");
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

}