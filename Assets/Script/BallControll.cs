using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GyroBallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 targetDirection;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float smoothing = 0.15f;
    public float maxSpeed = 5f;
    public float dragValue = 0.1f;

    [HideInInspector] public bool isGameStarted = false;

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody>();

        // Optimize physics for smooth rolling
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.drag = dragValue;
        rb.angularDrag = 1f;
        rb.mass = 1f;
    }

    void Update()
    {
        if (!isGameStarted) return;

        // Get device tilt from gyroscope
        Vector3 tilt = Input.gyro.gravity;

        // Adjust direction based on device orientation
        targetDirection = new Vector3(tilt.x, 0f, tilt.y).normalized;
    }

    void FixedUpdate()
    {
        if (!isGameStarted) return;

        // Smooth direction for fluid movement
        moveDirection = Vector3.Lerp(moveDirection, targetDirection, smoothing);

        // Calculate desired velocity
        Vector3 desiredVelocity = moveDirection * moveSpeed;
        desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, maxSpeed);

        // Apply velocity directly for smooth movement
        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);
    }
}
