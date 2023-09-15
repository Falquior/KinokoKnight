using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsContainer : MonoBehaviour
{
    public Vector2 pointerPosition { get; set; }

    [SerializeField] private Animator swordAnimator;

    [Tooltip("Cooldown for melee attacks of the character.")]
    [SerializeField] private float meleeDelay = 0.5f;
    [Tooltip("Cooldown for distance attacks of the character.")]
    [SerializeField] private float distanceDelay = 1.0f;
    [Tooltip("Arrows reload time")]
    [SerializeField] private float reloadTime = 3.0f;

    // Are the attacks freezed?
    private bool attackBlocked = false;
    private bool distanceAttackBlocked = false;

    [SerializeField] private SpriteRenderer characterRenderer, swordRenderer, crossbowRenderer;

    // Script that shoot arrows
    private CrossbowShooter arrowShooter;

    [Tooltip("Arrows available to shoot.")]
    [SerializeField] private int availableArrows = 5;
    [Tooltip("Max amount of arrow that character can store.")]
    [SerializeField] private int arrowsCapacity = 15;

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
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
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

    public void SetCrossbowVisibility(bool visibility)
    {
        crossbowRenderer.enabled = visibility;
    }

    public void SetSwordVisibility(bool visibility)
    {
        swordRenderer.enabled = visibility;
    }

    /// <summary>
    /// Plays Attack animation from animator
    /// </summary>
    public void Attack()
    {
        if (!attackBlocked)
        {
            swordAnimator.SetTrigger("Attack");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(meleeDelay);
        attackBlocked = false;
    }

    public void DistanceAttack()
    {
        if (!distanceAttackBlocked && availableArrows > 0)
        {
            arrowShooter.ShootArrow();
            availableArrows--;
            Debug.Log($"You have {availableArrows} available arrows.");
            distanceAttackBlocked = true;
            if (availableArrows > 0)
                StartCoroutine(DelayDistanceAttack());
            else
            {
                Debug.Log("reloading...");
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator DelayDistanceAttack()
    {
        yield return new WaitForSeconds(distanceDelay);
        distanceAttackBlocked = false;
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        availableArrows = arrowsCapacity;
        distanceAttackBlocked = false;
    }
}
