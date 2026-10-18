using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConroller : MonoBehaviour
{
    Rigidbody rb;
    Vector2 playerInput;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField]
    private float jumpForce = 5f;
    private bool canJump = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }

    void OnMove(InputValue input)
    {
        playerInput = input.Get<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 movementDirection = movementSpeed * playerInput.y * transform.forward;

        rb.linearVelocity = new Vector3(
            movementDirection.x,
            rb.linearVelocity.y,
            movementDirection.z
        );
    }

    private void RotatePlayer()
    {
        Quaternion rotation = Quaternion.Euler(
            0f,
            playerInput.x * rotationSpeed * Time.fixedDeltaTime,
            0f
        );

        rb.MoveRotation(rb.rotation * rotation);
    }

    private void OnJump()
    {
        if (canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}