using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class FalCharCon : MonoBehaviour
{
    public float speed;
    float xMov, yMov;
    bool dashActive = true;

    Rigidbody2D charRB;
    SpriteRenderer colorChange;
    Color origColor;
    // Start is called before the first frame update
    void Start()
    {
        charRB = GetComponent<Rigidbody2D>();
        colorChange = GetComponent<SpriteRenderer>();
        origColor = colorChange.color;
    }

    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        yMov = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space") && dashActive)
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        charRB.velocity = new Vector2(xMov, yMov) * speed * Time.deltaTime;  
    }

    IEnumerator Dash()
    {
        dashActive = false;
        speed = 700;
        colorChange.color = new Color(origColor.r, origColor.g, origColor.b, 0.5f) ;
        yield return new WaitForSeconds(2);
        speed = 500;
        colorChange.color = origColor;
        yield return new WaitForSeconds(5);
        dashActive = true;
    }
}
