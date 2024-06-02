using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Idle")]
public class IsIdleConditionSO : StateConditionSO<IsIdleCondition>
{

}

public class IsIdleCondition : Condition
{
    private PlayerController _playerController;
    private IsIdleConditionSO _originSO => (IsIdleConditionSO)base.OriginSO; // The SO this Condition spawned from

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
    }

    protected override bool Statement()
    {
        return _playerController._isIdle;
    }
}
