using StateMachine;
using StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Holding Jump")]
public class IsHoldingJumpConditionSO : StateConditionSO<IsHoldingJumpCondition> { }
public class IsHoldingJumpCondition : Condition
{
    //Component references
    private PlayerController _characterController;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _characterController = stateMachine.GetComponent<PlayerController>();
    }

    protected override bool Statement() => _characterController.IsJumpIpnut;
}
