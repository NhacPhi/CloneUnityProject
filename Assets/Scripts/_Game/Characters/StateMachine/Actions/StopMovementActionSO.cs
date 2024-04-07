using StateMachine;
using StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "StopMovementAction", menuName = "State Machines/Actions/Stop Movement")]
public class StopMovementActionSO : StateActionSO
{
    [SerializeField] private StateAction.SpecificMoment _moment = default;
    public StateAction.SpecificMoment Moment => _moment;

    protected override StateAction CreateAction() => new StopMovement();
}

public class StopMovement : StateAction
{
    private PlayerController _playerController;
    private new StopMovementActionSO OriginSO => (StopMovementActionSO)base.OriginSO;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
    }

    public override void OnUpdate()
    {
        if (OriginSO.Moment == SpecificMoment.OnUpdate)
            _playerController.movementVector = Vector3.zero;
    }

    public override void OnStateEnter()
    {
        if (OriginSO.Moment == SpecificMoment.OnStateEnter)
            _playerController.movementVector = Vector3.zero;
    }

    public override void OnStateExit()
    {
        if (OriginSO.Moment == SpecificMoment.OnStateExit)
            _playerController.movementVector = Vector3.zero;
    }
}

