using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GyroBallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;

    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float smoothing = 5f;

    [HideInInspector] public bool isGameStarted = false;

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody>();

        // Optional: Improve physics stability
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        if (!isGameStarted) return;

        // Get device tilt from gyroscope gravity vector
        Vector3 tilt = Input.gyro.gravity;

        // Adjust direction (depends on your device orientation)
        Vector3 rawDirection = new Vector3(tilt.x, 0f, tilt.y);

        // Smooth the movement direction for less jitter
        moveDirection = Vector3.Lerp(moveDirection, rawDirection, Time.deltaTime * smoothing);
    }

    void FixedUpdate()
    {
        if (!isGameStarted) return;

        // Apply rolling force based on smoothed direction
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
}
