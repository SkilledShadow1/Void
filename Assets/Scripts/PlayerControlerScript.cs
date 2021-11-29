using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerScript: MonoBehaviour
{
    protected Animator m_Anim;
    public float movementSpeed = 1;
    public float JumpForce = 5;
    public Animator animator;
    public AnimationClip idle;
    public AnimationClip run;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

        float movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Movement", Mathf.Abs(movement));

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;


        // && Mathf.Abs(_rigidbody.velocity.y) < 0.001f

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Debug.Log($"Jumping | IsGrounded {IsGrounded()}");
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float extraHeightTest = .1f;
        //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center + (Vector3.down * (boxCollider2D.bounds.extents.y + extraHeightTest)), Vector2.down, extraHeightTest);
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest);
        Color rayColor;
        
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            Debug.Log(raycastHit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("Is in the air");
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);
        return raycastHit.collider != null;
    }

    //private CharacterController controller;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    //private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    //private void Start()
    //{
    //    controller = gameObject.AddComponent<CharacterController>();
    //}

    //void Update()
    //{
    //    groundedPlayer = controller.isGrounded;
    //    if (groundedPlayer && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }

    //    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    controller.Move(move * Time.deltaTime * playerSpeed);

    //    if (move != Vector3.zero)
    //    {
    //        gameObject.transform.forward = move;
    //    }

    //    // Changes the height position of the player..
    //    if (Input.GetButtonDown("Jump") && groundedPlayer)
    //    {
    //        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    }

    //    playerVelocity.y += gravityValue * Time.deltaTime;
    //    controller.Move(playerVelocity * Time.deltaTime);
    //}
}
