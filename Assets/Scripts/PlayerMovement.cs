using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;

    private Vector2 moveInput;
    private Vector3 direction;
    private bool jumpPressed;
    private bool isGrounded;

    private void Update()
    {
        moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        if (InputSystem .actions["Jump"].WasPressedThisFrame()) jumpPressed = true;
    }

    private void FixedUpdate()
    {
        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
        direction = transform.localScale;
        if (moveInput.x > 0 && direction.x>0)
        {
            direction.x *= -1;
        }else if(moveInput.x < 0 && direction.x < 0)
        {
            direction.x *= -1;
        }
        transform.localScale = direction;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpStrength);
        }

        jumpPressed = false;
    }
}
