using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordContainer : MonoBehaviour
{
    public Vector2 pointerPosition { get; set; }
    
    [SerializeField] private Animator animator;
    [SerializeField] private float delay = 0.3f;
    
    private bool attackBlocked;

    [SerializeField] private SpriteRenderer characterRenderer, swordRenderer, crossbowRenderer;

    private CrossbowShooter arrowShooter;

    private void Start()
    {
        SetCrossbowVisibility(false);
        SetSwordVisibility(true);
        arrowShooter = GetComponentInChildren<CrossbowShooter>();
    }

    private void Update()
    {   
        // Aims sword to the cursor position
        Vector2 direction = (pointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        // Sets the scale to make the sword to be always pointing up
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
            scale.y = -1;
        else if (direction.x > 0)
            scale.y = 1;

        transform.localScale = scale;

        // Changes the order in layer of the sword to give a depth effect
        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            swordRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
            crossbowRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            swordRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
            crossbowRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    /// <summary>
    /// Plays Attack animation from animator
    /// </summary>
    public void Attack()
    {
        if(!attackBlocked)
        {
            animator.SetTrigger("Attack");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    public void SetCrossbowVisibility(bool visibility)
    {
        crossbowRenderer.enabled = visibility;
    }

    public void SetSwordVisibility(bool visibility)
    {
        swordRenderer.enabled = visibility;
    }

    public void DistanceAttack()
    {
        arrowShooter.ShootArrow();
    }

}
