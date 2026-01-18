using UnityEngine;
using UnityEngine.InputSystem;

public class FpsPlayer : MonoBehaviour
{
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;

    public float speed = 5f;
    public float xSens = 5f;
    public float ySens = 5f;

    public Transform cameraHolder;
    public Transform groundCheck;

    float xrot = 0f;

    public float jumpSpeed = 5f;
    Rigidbody rb;

    // [x] xRotation
    // [x] clamp rotation
    // [] rotation based movement
    // [] jump :)

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        bool isGrounded = IsGrounded();

        var move = moveAction.ReadValue<Vector2>();



        var movement = new Vector3(move.x, 0, move.y);
        var dir = transform.rotation * movement;
        dir.Normalize();
        dir *= speed;
        dir.y = rb.linearVelocity.y;

        if(jumpAction.triggered && isGrounded)
        {
            dir.y = jumpSpeed;
        }
        rb.linearVelocity = dir;



        var look = lookAction.ReadValue<Vector2>();
        var xLook = look.x * xSens;
        var yLook = -look.y * ySens;

        xrot += yLook * Time.deltaTime;

        xrot = Mathf.Clamp(xrot, -80, 80);

        cameraHolder.localRotation = Quaternion.Euler(xrot, 0,0);
        transform.Rotate(0, xLook * Time.deltaTime, 0);
    }

    // je to default :)
    private bool IsGrounded()
    {
        return Physics.Raycast(
            groundCheck.position,
            Vector3.down,
            0.04f
            );
    }
}
