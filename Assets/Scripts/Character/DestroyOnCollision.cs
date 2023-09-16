using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    FalPlantScript plantData;
    private void Start()
    {
        plantData = FindAnyObjectByType<FalPlantScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlantBoss"))
        {
            plantData.life -= 1.5f;
        }
        // Destroys if collides with a gameObject that is not an arrow
        if (!collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(this.gameObject);
        }
    }

}
