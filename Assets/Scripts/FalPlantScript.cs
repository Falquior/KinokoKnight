using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class FalPlantScript : MonoBehaviour
{
    int life = 100;
    string state = "Rest";
    float speed = 25;
    Rigidbody2D plantRB;
    public Transform target;
    float distanceToStop = 0;
    Vector2 origPos;
    Vector2 objectivePos;
    SpriteRenderer colorChange;
    Color origColor;
    // Start is called before the first frame update
    void Start()
    {
        plantRB = GetComponent<Rigidbody2D>();
        colorChange = GetComponent<SpriteRenderer>();
        StartCoroutine("EnemyAttack");
        origPos = transform.position;
        origColor = colorChange.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "CheckPos")
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }

    private void FixedUpdate()
    {
        if (state == "CheckPos")
        {
            objectivePos = target.transform.position;
        }
        if (state == "Attack")
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, objectivePos, Time.deltaTime * speed);
            plantRB.MovePosition(newPosition);
        }
        else if (state == "Return")
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, origPos, Time.deltaTime * speed);
            plantRB.MovePosition(newPosition);
        }
    }

    IEnumerator EnemyAttack()
    {
        state = "CheckPos";
        yield return new WaitForSeconds(3);
        state = "Alert";
        for (int i = 0; i < 5; i++)
        {
            colorChange.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(0.2f);
        }
        state = "Attack";
        yield return new WaitForSeconds(3);
        state = "Return";
        yield return new WaitForSeconds(1.5f);
        colorChange.color = origColor;
        StartCoroutine("EnemyAttack");
    }
}
