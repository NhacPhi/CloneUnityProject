using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ascend", menuName = "State Machines/Actions/Ascend")]
public class AscendActionSO : StateActionSO<AscendAction>
{
    [Tooltip("The initial upwards push when pressing jump. This is injected into verticalMovement, and gradually cancelled by gravity")]
    public float initialJumpForce = 6f;
}

public class AscendAction : StateAction
{
    //Component references
    private PlayerController _playerController;

    private CharacterController _characterController;


    private float _verticalMovement;
    private float _gravityContributionMultiplier;
    private AscendActionSO _originSO => (AscendActionSO)base.OriginSO; // The SO this StateAction spawned from

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
        _characterController = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnStateEnter()
    {
        //_verticalMovement = _originSO.initialJumpForce;
        _verticalMovement = 0;
        _playerController._isFalling = false;
         _playerController.deltaJump = 5;
        _playerController.movementVector.y = 0;
    }

    public override void OnUpdate()
    {
        if (_playerController.movementVector.y <= PlayerController.AIR_HIGH)
         {
            //_gravityContributionMultiplier += PlayerController.GRAVITY_COMEBACK_MULTIPLIER;
            //_gravityContributionMultiplier *= PlayerController.GRAVITY_DIVIDER; //Reduce the gravity effect

            //Note that deltaTime is used even though it's going to be used in ApplyMovementVectorAction, this is because it represents an acceleration, not a speed
            _verticalMovement = 15 * Time.deltaTime;

            _playerController.deltaJump -= _verticalMovement;
            //Note that even if it's added, the above value is negative due to Physics.gravity.y

            _playerController.movementVector.y += _verticalMovement;
        }
        else
        {
            _playerController._isFalling = true;
        }

    }
} 