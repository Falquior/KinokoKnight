using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private WeaponsContainer weaponsContainer;

    private Vector2 pointerInput;

    public bool swordActive = true;

    private void Awake()
    {
        weaponsContainer = GetComponentInChildren<WeaponsContainer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && swordActive)
            PerformMeleeAttack();
        else if(Input.GetKeyDown(KeyCode.Mouse1))
            PerformDistanceAttack();
        if (swordActive)
        {
            pointerInput = GetMousePosition();
            weaponsContainer.pointerPosition = pointerInput;
        }
        
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
        if (weaponsContainer != null)
        {
            weaponsContainer.SetSwordVisibility(true);
            weaponsContainer.SetCrossbowVisibility(false);
            weaponsContainer.Attack();
        }
    }

    private void PerformDistanceAttack()
    {
        if(weaponsContainer != null)
        {
            weaponsContainer.SetCrossbowVisibility(true);
            weaponsContainer.SetSwordVisibility(false);
            weaponsContainer.DistanceAttack();
        }
    }
}
