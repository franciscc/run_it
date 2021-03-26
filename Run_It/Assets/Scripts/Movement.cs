using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{

    public float _horizontalMove;
    public float _verticalMove;
    public float _fallVelocity;
    public float _jumpForce;

    public float _playerSpeed;
    public float _gravity = 9.8F;
    private Vector3 movePlayer;


    private Vector3 playerInput;

    public CharacterController player;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(_horizontalMove, 0, _verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        // Checking de cam direction
        CamDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * _playerSpeed;

        // Setting the direction to move
        player.transform.LookAt((player.transform.position + movePlayer) );
        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);
    }

    private void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    private void SetGravity()
    {
        if (player.isGrounded)
        {
            _fallVelocity = -_gravity * Time.deltaTime;
            movePlayer.y = _fallVelocity;
        }
        else
        {
            _fallVelocity -= _gravity * Time.deltaTime;
            movePlayer.y = _fallVelocity;
        }
    }

    private void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            _fallVelocity = _jumpForce;
            movePlayer.y = _fallVelocity;
        }
    }


}
