
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 direction;

    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Inputs")]
    public InputActionReference move;
    public InputActionReference jump;

    [Header("Detección de Suelo")]
    public float groundCheckDistance = 1.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (move != null && move.action != null)
            move.action.Enable();

        if (jump != null && jump.action != null)
            jump.action.Enable();
    }

    private void OnDisable()
    {
        if (move != null && move.action != null)
            move.action.Disable();

        if (jump != null && jump.action != null)
            jump.action.Disable();
    }

    private void Update()
    {
        // Leer movimiento
        if (move != null && move.action != null)
        {
            direction = move.action.ReadValue<Vector2>();
        }

        // Detectar suelo
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            groundCheckDistance,
            groundLayer
        );

        // Saltar
        if (jump != null && jump.action != null &&
            jump.action.WasPressedThisFrame() && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        velocity.x = direction.x * speed;

        rb.linearVelocity = velocity;
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            0f,
            rb.linearVelocity.z
        );

        rb.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
        );
    }
}
