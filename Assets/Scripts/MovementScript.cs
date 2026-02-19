using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;
    private float inputX;

    [InspectorLabel("Ground detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer = (1 << 6);
    [SerializeField] private bool isGrounded;

    [InspectorLabel("Extended Jumping")]
    [SerializeField] float jumpForce = 5f;
    bool isJumping;
    [SerializeField] float jumpTime = 0.5f;
    float jumpTimeLeft;

    [InspectorLabel("Coyote time and jumpbuffer")]
    [SerializeField] private float coyoteTime = 0.2f;
    float coyoteTimeLeft;
    [SerializeField] float jumpBufferTime = 0.2f;
    [SerializeField] float jumpBufferCounter;
    bool jump = false;

 
    

    private bool playerisDead = false;
    public void SetPlayerDead(bool val)
    {
        playerisDead = val;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    //----- Physics update -----\\
    private void FixedUpdate()
    {
       
        PlayerJump();
    }

    //----- Movement -----\\
    private void MovingPlayer()
    {
        rb.linearVelocity = new Vector2(inputX * speed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * 1.5f * Time.fixedDeltaTime);
        }
    }
    //----- Jumping methods -----\\
    private void PlayerJump()
    {
        //Coyote time 
        if (isGrounded)
        {
        
            coyoteTimeLeft = coyoteTime;
        }
        else
        {
            coyoteTimeLeft -= Time.deltaTime;
        }

        //Jump buffer (for missclicked jumps)
        if (jump)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        //Jump mechanics
        if (jumpBufferCounter > 0f && coyoteTimeLeft > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
            jumpTimeLeft = jumpTime;
            coyoteTimeLeft = 0;
            jumpBufferCounter = 0;

        }
        //Holding jump (longer jumps)
        if (jump && isJumping)
        {
            if (jumpTimeLeft > 0)
            {
                jumpTimeLeft -= Time.deltaTime;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
        //stop jumping
        if (!jump)
        {
            isJumping = false;
        }
    }
}