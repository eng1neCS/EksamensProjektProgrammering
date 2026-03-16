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


    public string PlayerID { get => playerID;}

    public LayerMask groundLayer;

    Rigidbody2D rb;
    //float g = 2f;
    public Transform groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Debug.Log(g);
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal"+playerID);
       
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

        //if (Input.GetButtonDown("Preset1"))
        //{
        //    float jumpForce = 14f;
        //    float g = 2f;
        //}

        //if (Input.GetButtonDown("Preset2"))
        //{
        //    float jumpForce = 17f;
        //    float g = 3.5f;
        //}
        
        //if (Input.GetButtonDown("Preset3"))
        //{
        //    float jumpForce = 10f;
        //    float g = 2.5f;
        //}
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

}