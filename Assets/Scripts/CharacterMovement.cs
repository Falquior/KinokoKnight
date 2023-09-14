using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Gets inputs for horizontal and vertical movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        moveInput = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Moves the character
        rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
    }


}
