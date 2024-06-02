using StateMachine;
using StateMachine.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimatorJumpingSpeedAction", menuName = "State Machines/Actions/Set Animator Jumping")]
public class AnimatorJumpingActionSO : StateActionSO
{
    public string parameterName = default;
    protected override StateAction CreateAction() => new AnimatorJumpingAction(Animator.StringToHash(parameterName));
}

public class AnimatorJumpingAction : StateAction
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

    public AnimatorJumpingAction(int parameterHash)
    {
        _parameterHash = parameterHash;
    }

    public override void OnUpdate()
    {
         float normalisedSpeed = _playerController.deltaJump;
        _animator.SetFloat(_parameterHash, normalisedSpeed);
    }
}

