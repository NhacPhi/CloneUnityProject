using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HorizontalMove", menuName = "State Machines/Actions/Horizontal Move")]
public class HorizontalMoveActionSO : StateActionSO<HorizontalMoveAction>
{
    [Tooltip("Horizontal XZ plane speed multiplier")]
    public float speed = 2f;
}

public class HorizontalMoveAction : StateAction
{
    //Component references
    private PlayerController _playerController;
    private HorizontalMoveActionSO _originSO => (HorizontalMoveActionSO)base.OriginSO; // The SO this StateAction spawned from

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
    }

    public override void OnUpdate()
    {
        //delta.Time is used when the movement is applied (ApplyMovementVectorAction)
        _playerController.movementVector = _playerController.movementInput * _originSO.speed;
        Debug.Log("movementVector: " + _playerController.movementVector);
    }
}
