using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    private BoxCollider2D swordCollider;
    FalPlantScript plantData;

    private void Start()
    {
        swordCollider = GetComponent<BoxCollider2D>();
        plantData = FindAnyObjectByType<FalPlantScript>();
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlantBoss"))
        {
            plantData.life -= 5;
        }
    }

    public void ActivateCollision()
    {
        swordCollider.enabled = true;
    }

    public void DeactivateCollision()
    {
        swordCollider.enabled = false;
    }
}
