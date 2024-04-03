using Cinemachine;
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

    public CinemachineFreeLook _gameCamera;

    private CharacterController _charCtrl;
    private bool _isGrounded = true;
    private bool _ReadyToJump;

    private bool isActiveCursor;
    // Start is called before the first frame update

    private void Start()
    {
        //Screen.lockCursor = true;
        isActiveCursor = true;

        _charCtrl = GetComponent<CharacterController>();
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
        Debug.Log("Movement Vec2: " + _inputVector);
    }
    private void RecalculateMovement()
    {
        Vector3 adjustedMovement;

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
        else
        {
            //No CameraManager exists in the scene, so the input is just used absolute in world-space
            Debug.LogWarning("No gameplay camera in the scene. Movement orientation will not be correct.");
            adjustedMovement = new Vector3(_inputVector.x, 0f, _inputVector.y);
        }

        //Debug.Log("_inputVector " + _inputVector);
        //Fix to avoid getting a Vector3.zero vector, which would result in the player turning to x:0, z:0
        if (_inputVector.sqrMagnitude != 0f)
        {
            _charCtrl.Move(adjustedMovement*Time.deltaTime * _maxForewardSpeed);
        }

    }
}
