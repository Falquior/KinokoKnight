using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class FalPlantScript : MonoBehaviour
{
    int life = 100;
    string state = "Rest";
    float speed = 300;
    Rigidbody2D plantRB;
    public Transform target;
    float distanceToStop = 0;
    // Start is called before the first frame update
    void Start()
    {
        plantRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "Rest")
        {
            //StartCoroutine(EnemyAttack());
            state = "Awaken";
        }
    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator EnemyAttack()
    {
        while (life > 0)
        {
            while (Vector3.Distance(transform.position, target.position) > distanceToStop)
            {
                Debug.Log("Ta lejos");
                transform.LookAt(target);
                plantRB.AddRelativeForce(Vector3.forward * speed, ForceMode2D.Force);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
