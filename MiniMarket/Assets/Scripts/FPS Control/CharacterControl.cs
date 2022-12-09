using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed = 7.5f;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector2 LookAxis;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    public void SetLookAxis (Vector2 n)
    {
        LookAxis = n;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _horizontalInput = _joystick.Horizontal;
        _verticalInput = _joystick.Vertical;

        moveDirection = transform.TransformDirection(new Vector3(_horizontalInput * _speed, 0, _verticalInput * _speed));
        characterController.Move(moveDirection * Time.deltaTime);

        
        rotationX += -LookAxis.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, LookAxis.x * lookSpeed, 0);
    }
}
