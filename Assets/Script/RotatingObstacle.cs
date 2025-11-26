using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Rotate around Y-axis by default

    void Update()
    {
        // Rotate around its local axis
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
