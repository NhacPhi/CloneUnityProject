using UnityEngine;
using StateMachine;
using StateMachine.ScriptableObjects;
[CreateAssetMenu(fileName = "ApplyMovementVector", menuName ="State Machines/Actions/Apply Movement Vector")]
public class ApplyMovementVectorActionSO : StateActionSO<ApplyMovementVectorAction> { }

public class ApplyMovementVectorAction : StateAction
{
    // component reference
    private PlayerController _playerController;
    private CharacterController _characterController;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        //base.Awake(stateMachine);
        _playerController = stateMachine.GetComponent<PlayerController>();
        _characterController = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnUpdate()
    {
        _characterController.Move(_playerController.movementVector * Time.deltaTime);
        //_playerController.movementVector = _characterController.velocity;
    }
}

