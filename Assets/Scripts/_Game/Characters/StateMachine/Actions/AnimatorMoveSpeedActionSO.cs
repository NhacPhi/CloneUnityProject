using StateMachine;
using StateMachine.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimatorMoveSpeedAction", menuName = "State Machines/Actions/Set Animator Move Speed")]
public class AnimatorMoveSpeedActionSO : StateActionSO
{
    public string parameterName = default;
    protected override StateAction CreateAction() => new AnimatorMoveSpeedAction(Animator.StringToHash(parameterName));
}

public class AnimatorMoveSpeedAction : StateAction
{
    // Component refernces
    private Animator _animator;
    private PlayerController _playerController;

    private AnimatorParameterActionSO _originSO => (AnimatorParameterActionSO)base.OriginSO; // The SO this StateAction spawned from
    private int _parameterHash;

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Animator>();
        _playerController = stateMachine.GetComponent<PlayerController>();
    }

    public AnimatorMoveSpeedAction(int parameterHash)
    {
        _parameterHash = parameterHash;
    }

    public override void OnUpdate()
    {
        float normalisedSpeed = _playerController.movementInput.magnitude;
        _animator.SetFloat(_parameterHash, normalisedSpeed);
    }
}
