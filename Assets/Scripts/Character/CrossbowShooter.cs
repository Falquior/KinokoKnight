using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowShooter : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowSpeed = 10.0f;

    public void ShootArrow()
    {
        // Get the initial rotation and adjust it by -90 degrees on the Z-axis.
        Quaternion arrowRotation = transform.rotation * Quaternion.Euler(0,0,-90);
        GameObject arrow = Instantiate(arrowPrefab, transform.position, arrowRotation);
        

        // Access the Rigidbody2D of the arrow and apply velocity.
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * arrowSpeed;
    }
}
