using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashAlert : MonoBehaviour
{
    CharacterMovement charmov;
    RawImage colorChange;
    // Start is called before the first frame update
    void Start()
    {
        charmov = FindAnyObjectByType<CharacterMovement>();
        colorChange = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!charmov.dashAvailable)
        {
            colorChange.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            colorChange.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
