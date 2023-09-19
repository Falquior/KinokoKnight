using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLife : MonoBehaviour
{
    private UIFuntions UIFuntions;
    [SerializeField] public GameObject[] lifes;
    public int numLifes;
    public int hits = 0;
    [SerializeField] private GameOver gameOver;

    // Make all life sprites visible.
    public void ActivateLifes()
    {
        for (int i = 0; i < lifes.Length; i++) {
            lifes[i].SetActive(true);
        }
    }

    // Hide one life when player get hit and activate game over panel if player die.
    public void DeActivatedOneLife(int numLife, int hits)
    {
        if (hits -1 >= 0) 
            lifes[hits-1].SetActive(false);

        if (numLife == hits) 
        {
            gameOver.Enable();
            
            // METHOD FROM UIFuntions to activated GameOver Menu and pause game.
            // CHARACTER DEATH ANIMATION
        }
    }

    // Detect collisions between the GameObjects with Colliders attached
    void EnemyHit(Collision collision)
    {
        
    }

}