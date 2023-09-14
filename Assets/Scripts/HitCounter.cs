using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HitCounter : MonoBehaviour
{
    private uint hits = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sword"))
            Count();
        else if(collision.CompareTag("Arrow"))
            Count();
    }

    private void Count()
    {
        hits++;
        Debug.Log("Hit counter attacked, hits: " + hits.ToString());
    }
}
