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
    // Start is called before the first frame update
    void Start()
    {
        charRB = GetComponent<Rigidbody2D>();
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
        yield return new WaitForSeconds(2);
        speed = 500;
        yield return new WaitForSeconds(10);
        dashActive = true;
    }
}
