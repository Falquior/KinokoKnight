using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    private BoxCollider2D swordCollider;

    private void Start()
    {
        swordCollider = GetComponent<BoxCollider2D>();
        swordCollider.enabled = false;
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
