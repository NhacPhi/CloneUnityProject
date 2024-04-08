using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _ipnutReader = default;
    [SerializeField] private TransformAnchor _gameplayCameraTransform = default;

    private Vector2 _inputVector;

    [SerializeField] private float _maxForewardSpeed = 8f;
    [SerializeField] private float _gravity = 20f;
    [SerializeField] private float _jumpSpeed = 10f;

    [NonSerialized] public Vector3 movementInput; //Initial input coming from the Protagonist script
    [NonSerialized] public Vector3 movementVector; //Final movement vector, manipulated by the StateMachine actions

    public CinemachineFreeLook _gameCamera;

    private CharacterController _charCtrl;
    private bool _isGrounded = true;
    private bool _ReadyToJump;

    readonly int _HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
    private Animator _Animator;
    // Start is called before the first frame update

    private void Start()
    {
        _ipnutReader.EnableGamePlay();

#if UNITY_EDITOR_WIN
        Screen.lockCursor = true;
#endif

#if UNITY_STANDALONE_WIN
        Screen.lockCursor = true;
#endif
        //isActiveCursor = true;

        _charCtrl = GetComponent<CharacterController>();
        Debug.Log("_charCtrl :" + _charCtrl.velocity);
        _Animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _ipnutReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _ipnutReader.MoveEvent -= OnMove;
    }

    private void Update()
    {
        RecalculateMovement();

    }

    private void OnMove(Vector2 movement)
    {
        _inputVector = movement;
    }
    private void RecalculateMovement()
    {
        Vector3 adjustedMovement = Vector3.zero;

        if (_inputVector.sqrMagnitude != 0f)
        {
            if (_gameplayCameraTransform.isSet)
            {
                //Get the two axes from the camera and flatten them on the XZ plane
                Vector3 cameraForward = _gameplayCameraTransform.Value.forward;
                cameraForward.y = 0f;
                Vector3 cameraRight = _gameplayCameraTransform.Value.right;
                cameraRight.y = 0f;

                //Use the two axes, modulated by the corresponding inputs, and construct the final vector
                adjustedMovement = cameraRight.normalized * _inputVector.x +
                    cameraForward.normalized * _inputVector.y;
            }

            movementInput = adjustedMovement.normalized;



        }
        else
        {
            movementInput = Vector3.zero;
        }

    }

}
