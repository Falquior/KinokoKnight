using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{
    [Tooltip("Speed of the character movement.")]
    [SerializeField] private float moveSpeed = 500.0f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    // is the character using the dash?
    public bool activeDash = false;
    // Is the dash ready for usage?
    public bool dashAvailable = true;
    [Tooltip("Speed of the character when the dash is used.")]
    [SerializeField] private float dashSpeed = 1000.0f;
    [Tooltip("Duration in seconds of the dash.")]
    [SerializeField] private float dashDuration = 2.0f;
    [Tooltip("Cooldown in seconds of the dash.")]
    [SerializeField] private float dashCooldown = 10f;

    PlayersLife lifeControl;
    bool charDamagable;
    bool isGettingHit = false;
    SpriteRenderer colorChange;
    Color origColor;
    Animator anim;

    CinemachineVirtualCamera vcam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeControl = FindAnyObjectByType<PlayersLife>();
        colorChange = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        origColor = colorChange.color;
        vcam =  FindAnyObjectByType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGettingHit == false)
        {
            if(collision.GetType() == typeof(CapsuleCollider2D))
            {
                if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("PlantBoss"))
                {
                    if (charDamagable)
                    {
                        StartCoroutine("Hits");
                    }
                }
            }
        }
        
    }

    IEnumerator Hits()
    {
        isGettingHit = true;
        lifeControl.numLifes = lifeControl.lifes.Length;
        lifeControl.hits++;
        lifeControl.DeActivatedOneLife(lifeControl.numLifes, lifeControl.hits);
        yield return new WaitForSeconds(3);
        isGettingHit = false;
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
        //Animation
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
        anim.SetFloat("InputX", mousepos.x);
        anim.SetFloat("InputY", mousepos.y);

        Vector2 mouse2norm = mousepos.normalized;
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f + mouse2norm.x * -0.2f;
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f + mouse2norm.y * 0.2f;
        if(isGettingHit) colorChange.color = new Color( 100 , 0, 0, 0.5f);
        else if (!activeDash) colorChange.color = origColor;
    }

    private void FixedUpdate()
    {
        // Moves the character
        if (!activeDash)
        {
            rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
            colorChange.color = origColor;
            charDamagable = true;
        }

        else
        {
            rb.velocity = moveInput * dashSpeed * Time.fixedDeltaTime;
            colorChange.color = new Color(origColor.r, origColor.g, origColor.b, 0.5f);
            charDamagable = false;
        }
    }

    private IEnumerator Dash()
    {
        yield return new WaitForSeconds(dashDuration);
        activeDash = false;
        yield return new WaitForSeconds(dashCooldown);
        dashAvailable = true;
    }

}
