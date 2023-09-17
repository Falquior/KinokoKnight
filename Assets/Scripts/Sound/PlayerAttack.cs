using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip attackSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void attackSFX()
    {
        audioSource.Play();
    }
}
