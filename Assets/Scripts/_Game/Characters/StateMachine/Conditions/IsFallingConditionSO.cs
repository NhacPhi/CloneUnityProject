using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Falling")]
public class IsFallingConditionSO : StateConditionSO<IsFallingCondition> { }
public class IsFallingCondition : Condition
{
    //Component references
    private PlayerController _characterController;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _characterController = stateMachine.GetComponent<PlayerController>();
    }

    protected override bool Statement() => _characterController._isFalling;
}

