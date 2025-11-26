using UnityEngine;

public class LoopingLeftRightMovement : MonoBehaviour
{
    public float moveDistance = 3f;    // Total distance to move left and right
    public float moveSpeed = 2f;       // Speed of movement

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Move toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // If the block reaches the target, switch direction
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            movingRight = !movingRight;
            targetPos = startPos + (movingRight ? Vector3.right : Vector3.left) * moveDistance;
        }
    }
}
