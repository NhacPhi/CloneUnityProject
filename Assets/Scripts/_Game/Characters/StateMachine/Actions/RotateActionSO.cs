using StateMachine.ScriptableObjects;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotateAction", menuName = "State Machines/Actions/Rotate")]
public class RotateActionSO : StateActionSO<RotateAction>
{
    [Tooltip("Smoothing for rotating the character to their movement direction")]
    public float turnSmoothTime = 0.2f;
}

public class RotateAction : StateAction
{
    //Component references
    private PlayerController _playerController;
    private Transform _transform;

    private float _turnSmoothSpeed; //Used by Mathf.SmoothDampAngle to smoothly rotate the character to their movement direction
    private const float ROTATION_TRESHOLD = .02f; // Used to prevent NaN result causing rotation in a non direction
    private RotateActionSO _originSO => (RotateActionSO)base.OriginSO; // The SO this StateAction spawned from

    public override void Awake(StateMachine.StateMachine stateMachine)
    {
        _playerController = stateMachine.GetComponent<PlayerController>();
        _transform = stateMachine.GetComponent<Transform>();
    }

    public override void OnUpdate()
    {
        Vector3 horizontalMovement = _playerController.movementVector;
        horizontalMovement.y = 0f;

        if (horizontalMovement.sqrMagnitude >= ROTATION_TRESHOLD)
        {
            float targetRotation = Mathf.Atan2(_playerController.movementVector.x, _playerController.movementVector.z) * Mathf.Rad2Deg;
            _transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetRotation,
                ref _turnSmoothSpeed,
                _originSO.turnSmoothTime);
        }
    }
}