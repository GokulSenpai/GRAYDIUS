using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastItself : MonoBehaviour
{

    public float ChasingRange=4f;
    public float SpawningRange=4.5f;
    private bool MadeEnemyVisible = false;
    private bool Canchase = false;
    public  float speed = 5f;

    private Transform Player;

    private LevelGeneration LGRef;
    private Animator Anim;
    void Start()
    {
        LGRef =GameObject.Find("LevelGeneration").GetComponent<LevelGeneration>();
        //  Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Player = LGRef.Player.transform;
        this.GetComponent<SpriteRenderer>().enabled=false;
    }

    void Update()
    {
        if (LGRef.EnemiesSpawned)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < SpawningRange)
            {
                MadeEnemyVisible = true;
            }
            if (MadeEnemyVisible)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (Vector3.Distance(transform.position, Player.transform.position) < ChasingRange)
            {
                Canchase = true;
            }
            if (Canchase)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //play Death animation
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //Reduce Player Health;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet")| collision.gameObject.CompareTag("Ground")| collision.gameObject.CompareTag("Teleport"))
        {
            Destroy(gameObject);
        }
    }
}
