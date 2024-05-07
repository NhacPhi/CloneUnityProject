using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Character Controller Grounded")]
public class IsCharacterControllerGroundedConditionSO : StateConditionSO<IsCharacterControllerGroundedCondition> { }

public class IsCharacterControllerGroundedCondition : Condition
{
    private CharacterController _characterController;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _characterController = stateMachine.GetComponent<CharacterController>();
    }

    protected override bool Statement() => _characterController.isGrounded;
}
