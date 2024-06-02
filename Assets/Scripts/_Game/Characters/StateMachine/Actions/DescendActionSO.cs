using StateMachine;
using StateMachine.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/Actions/Descend")]
public class DescendActionSO : StateActionSO<DescendAction> { }
public class DescendAction : StateAction
{
    //Component references
    private PlayerController _playerController;


    private CharacterController _characterController;


    private float _verticalMovement;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
        _characterController = stateMachine.GetComponent<CharacterController>();
    }

    public override void OnStateEnter()
    {
        //_verticalMovement = _playerController.movementVector.y;
        _verticalMovement = 0;
        //Prevents a double jump if the player keeps holding the jump button
        //Basically it "consumes" the input
                                 _playerController.IsJumpIpnut = false;
        _playerController.deltaJump = 0;
    }

    public override void OnUpdate()
    {
        //Note that deltaTime is used even though it's going to be used in ApplyMovementVectorAction, this is because it represents an acceleration, not a speed
        //_verticalMovement += Physics.gravity.y * PlayerController.GRAVITY_MULTIPLIER * Time.deltaTime;
        //Note that even if it's added, the above value is negative due to Physics.gravity.y

        //Cap the maximum so the player doesn't reach incredible speeds when freefalling from high positions
        // _verticalMovement = Mathf.Clamp(_verticalMovement, PlayerController.MAX_FALL_SPEED, PlayerController.MAX_RISE_SPEED);
        if(!_characterController.isGrounded)
        {
            _verticalMovement = 20 * Time.deltaTime;

            _playerController.deltaJump -= _verticalMovement;

            _playerController.movementVector.y -= _verticalMovement;
        }
        else
        {
            _playerController._isFalling = false;
        }
    }
}
