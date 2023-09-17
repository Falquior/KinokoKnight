using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAlert : MonoBehaviour
{
    WeaponsContainer arrows;
    RawImage colorChange;
    // Start is called before the first frame update
    void Start()
    {
        arrows = FindAnyObjectByType<WeaponsContainer>();
        colorChange = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrows.availableArrows == 0)
        {
            colorChange.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            colorChange.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
