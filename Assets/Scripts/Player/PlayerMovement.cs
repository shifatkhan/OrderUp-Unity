﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is only responsible for the player's movements.
/// 
/// @author ShifatKhan
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player stats")]// TODO: Replace this with a ScriptableObject.
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3.5f;
    [SerializeField] private float turnSpeed = 50f;

    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        UpdateFaceDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Move the player according to the world space.
    /// </summary>
    private void Move()
    {
        // Add move speed.
        Vector3 movement = playerInput.directionalInput * moveSpeed;

        // Move.
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Rotate the player towards the direction it is moving.
    /// </summary>
    private void UpdateFaceDirection()
    {
        if (playerInput.directionalInput.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(playerInput.directionalInput), turnSpeed * Time.deltaTime);
        }
    }
}