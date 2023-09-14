using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private SwordContainer swordContainer;

    private Vector2 pointerInput;

    private void Awake()
    {
        swordContainer = GetComponentInChildren<SwordContainer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            PerformMeleeAttack();
        else if(Input.GetKeyDown(KeyCode.Mouse1))
            PerformDistanceAttack();

        pointerInput = GetMousePosition();
        swordContainer.pointerPosition = pointerInput;
    }

    private Vector2 GetMousePosition()
    {
        // Get the cursor position in pixels from the bottom-left corner of the screen
        Vector3 mousePosition = Input.mousePosition;
        // Convert the cursor position from pixels to world units, and returns it
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void PerformMeleeAttack()
    {
        if (swordContainer != null)
        {
            swordContainer.SetSwordVisibility(true);
            swordContainer.SetCrossbowVisibility(false);
            swordContainer.Attack();
        }
    }

    private void PerformDistanceAttack()
    {
        if(swordContainer != null)
        {
            swordContainer.SetCrossbowVisibility(true);
            swordContainer.SetSwordVisibility(false);
            swordContainer.DistanceAttack();
        }
    }
}
