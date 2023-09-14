using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalBullSpawnScript : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Hose }
    [Header("Shooting attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    public float bulletLife = 1f;
    public float speed = 1f;
    private float timer = 0f;
    private Quaternion origRot;
    [Header("Bullets")]
    public GameObject bullet;
    private GameObject spawnedBullet;
    private void Start()
    {
        origRot = transform.rotation;
        StartCoroutine("BulletSet");
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.rotation = Quaternion.Euler(0f, 0f, -90 + 500 * Time.time);
        if (spawnerType == SpawnerType.Hose) transform.rotation = Quaternion.Euler(0f, 0f, -90 + 50 * Mathf.Sin(Time.time * 10));
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }
    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<FalBulletScript>().speed = speed;
            spawnedBullet.GetComponent<FalBulletScript>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }

    IEnumerator BulletSet()
    {
        speed = 10;
        bulletLife = 3;
        transform.rotation = origRot;
        spawnerType = SpawnerType.Straight;
        yield return new WaitForSeconds (3);
        bulletLife = 0;
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = 10;
        bulletLife = 3;
        transform.rotation = origRot;
        spawnerType = SpawnerType.Spin;
        yield return new WaitForSeconds(3);
        bulletLife = 0;
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = 10;
        bulletLife = 3;
        transform.rotation = origRot;
        spawnerType = SpawnerType.Hose;
        yield return new WaitForSeconds(3);
        bulletLife = 0;
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("BulletSet");
    }
}
