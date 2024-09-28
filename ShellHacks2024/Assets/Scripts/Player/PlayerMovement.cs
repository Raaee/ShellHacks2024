using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5.0f;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    private void FixedUpdate()
    {
        movementInput = inputManager.movement.ReadValue<Vector2>();
    }
}
