using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementScript : MonoBehaviour
{ 
    [SerializeField] private string playerID = "P1";
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float groundCheckRadius = 2f;

    [SerializeField] private float coyoteTime = 0.2f;
    float coyoteTimeLeft;
    [SerializeField] float jumpBufferTime = 0.2f;
    float jumpBufferCounter;


    public LayerMask groundLayer;

    Rigidbody2D rb;
    public Transform groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal"+playerID);
        Debug.Log("test: x = " + move);
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (IsGrounded())
        {
            coyoteTimeLeft = coyoteTime;
        }
        else
        {
            coyoteTimeLeft -= Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Jump"+playerID))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.fixedDeltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeLeft > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            coyoteTimeLeft = 0;
            jumpBufferCounter = 0;
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

}