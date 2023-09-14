using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float verticalBound = 15.0f;
    private float horizontalBound = 20.0f;

    private void FixedUpdate()
    {
        if (transform.position.y > verticalBound || transform.position.y < -verticalBound)
            Destroy(gameObject);
        else if (transform.position.x > horizontalBound || transform.position.x < -horizontalBound)
            Destroy(gameObject);
    }
}
