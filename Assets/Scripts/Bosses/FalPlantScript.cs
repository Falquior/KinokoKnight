using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class FalPlantScript : MonoBehaviour
{
    [Header ("Plant Attributes")]
    [SerializeField] public int life = 100;
    string state = "Rest";
    int phase = 1;
    Vector2 origPos;
    [Header("Plant Attack Settings")]
    float speed = 25;
    float speedb = 35;
    float speedc = 50;
    float distanceToStop = 0;
    public Transform target;
    Vector2 objectivePos;
    [Header("Plant Components")]
    Rigidbody2D plantRB;
    SpriteRenderer colorChange;
    Color origColor;
    Animator plantAnim;
    // Start is called before the first frame update
    void Start()
    {
        plantRB = GetComponent<Rigidbody2D>();
        colorChange = GetComponent<SpriteRenderer>();
        plantAnim = GetComponent<Animator>();
        StartCoroutine("EnemyAttack");
        StartCoroutine("PhaseCheck");
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
            Vector2 newPosition = Vector2.MoveTowards(transform.position, objectivePos, Time.deltaTime * speedb);
            plantRB.MovePosition(newPosition);
        }
        else if (state == "Return")
        {
            colorChange.color = origColor;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, origPos, Time.deltaTime * speedb);
            plantRB.MovePosition(newPosition);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            life = life - 10;
        }
    }
    IEnumerator PhaseCheck()
    {
        if (life <= 50 && life >= 26 && phase == 1)
        {
            StopCoroutine("EnemyAttack");
            state = "Return";
            yield return new WaitForSeconds(1);
            StartCoroutine("EnemyAttackBerserk1");
            phase = 2;
        }
        if (life <= 25 && life >= 1 && phase == 2)
        {
            StopCoroutine("EnemyAttackBerserk1");
            state = "Return";
            yield return new WaitForSeconds(1);
            StartCoroutine("EnemyAttackBerserk2");
            phase = 3;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("PhaseCheck");
    }
    IEnumerator EnemyAttack()
    {
        state = "CheckPos";
        plantAnim.SetInteger("PlantStatus", 0);
        yield return new WaitForSeconds(3);
        state = "Alert";
        plantAnim.SetInteger("PlantStatus", 1);
        for (int i = 0; i < 5; i++)
        {
            //colorChange.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(0.2f);
        }
        state = "Attack";
        plantAnim.SetInteger("PlantStatus", 2);
        yield return new WaitForSeconds(3);
        state = "Return";
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("EnemyAttack");
    }

    IEnumerator EnemyAttackBerserk1()
    {
        state = "CheckPos";
        yield return new WaitForSeconds(2f);
        state = "Alert";
        for (int i = 0; i < 5; i++)
        {
            colorChange.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(0.15f);
        }
        state = "Attack";
        yield return new WaitForSeconds(2);
        state = "Return";
        yield return new WaitForSeconds(1f);
        StartCoroutine("EnemyAttackBerserk1");
    }
    IEnumerator EnemyAttackBerserk2()
    {
        state = "CheckPos";
        yield return new WaitForSeconds(1f);
        state = "Alert";
        for (int i = 0; i < 5; i++)
        {
            colorChange.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        state = "Attack";
        yield return new WaitForSeconds(1.5f);
        state = "Return";
        yield return new WaitForSeconds(0.75f);
        StartCoroutine("EnemyAttackBerserk2");
    }
}
