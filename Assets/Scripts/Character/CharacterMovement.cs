using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Tooltip("Speed of the character movement.")]
    [SerializeField] private float moveSpeed = 500.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    // is the character using the dash?
    private bool activeDash = false;
    // Is the dash ready for usage?
    private bool dashAvailable = true;
    [Tooltip("Speed of the character when the dash is used.")]
    [SerializeField] private float dashSpeed = 1000.0f;
    [Tooltip("Duration in seconds of the dash.")]
    [SerializeField] private float dashDuration = 2.0f;
    [Tooltip("Cooldown in seconds of the dash.")]
    [SerializeField] private float dashCooldown = 10.0f;

    PlayersLife lifeControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeControl = FindAnyObjectByType<PlayersLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifeControl.numLifes = lifeControl.lifes.Length;

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("PlantBoss"))
        {
            lifeControl.hits++;
            lifeControl.DeActivatedOneLife(lifeControl.numLifes, lifeControl.hits);
        }
    }

    private void Update()
    {
        // Gets inputs for horizontal and vertical movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        moveInput = new Vector2(horizontalInput, verticalInput).normalized;
        if(Input.GetKeyDown(KeyCode.Space) && dashAvailable)
        {
            dashAvailable = false;
            activeDash = true;
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        // Moves the character
        if(!activeDash)
            rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
        else
            rb.velocity = moveInput * dashSpeed * Time.fixedDeltaTime;

    }

    private IEnumerator Dash()
    {
        Debug.Log("Dash start");
        yield return new WaitForSeconds(dashDuration);
        activeDash = false;
        Debug.Log("Dash end, cooldown");
        yield return new WaitForSeconds(dashCooldown);
        dashAvailable = true;
        Debug.Log("Dash restored");
    }

}
