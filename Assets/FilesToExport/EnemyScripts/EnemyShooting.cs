using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    public Transform target;
    private Transform BulletSpawningPos;
    private Transform enemy;
    public GameObject EnemyBullet;
    public float AttackRange;
    public float FireRate = 1f;
    private float nextFire;


    private EnemyPatrol EPRef;
    private LevelGeneration LGRef;

    void Start()
    {
        enemy = this.gameObject.transform;
        BulletSpawningPos = this.gameObject.transform;
        LGRef = GameObject.Find("LevelGeneration").GetComponent<LevelGeneration>();
        target = LGRef.Player.transform;

        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EPRef = GetComponent<EnemyPatrol>();

        nextFire = Time.time;
    }


    void Update()
    {
        if (LGRef.EnemiesSpawned)
        {
            EPRef.canMove = true;
            Shooting();
        }
    }

    void Shooting()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < AttackRange)
        {
            EPRef.canMove = false;

            if (Time.time > nextFire)
            {
                Instantiate(EnemyBullet, BulletSpawningPos.position, Quaternion.identity);
                nextFire = Time.time + FireRate;
            }
        }
        else
        {
            EPRef.canMove = true;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
