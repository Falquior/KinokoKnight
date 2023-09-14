using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroys if collides with a gameObject that is not an arrow
        if (!collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(this.gameObject);
        }
    }

}
