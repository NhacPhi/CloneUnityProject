using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "State Machines/Conditions/Started Moving")]
public class IsMovingConditionSO : StateConditionSO<IsMovingCondition>
{
    public float treshold = 0.02f;
}

public class IsMovingCondition : Condition
{
    private PlayerController _playerController;
    private IsMovingConditionSO _originSO => (IsMovingConditionSO)base.OriginSO; // The SO this Condition spawned from

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
    }

    protected override bool Statement()
    {
        Vector3 movementVector = _playerController.movementInput;
        movementVector.y = 0f;
        return movementVector.sqrMagnitude > _originSO.treshold;
    }
}
