using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelle : MonoBehaviour
{

    public Transform target;
    public Transform AttackPoint; 
    public float AttackRange;
    public LayerMask PlayerLayer;

    [SerializeField] public float DetectRange;
    [SerializeField] private bool MoveTowardsPlayer=false;
    [SerializeField] public float closeRange=1;
    [SerializeField] private bool canAttack = false;
    [SerializeField] private bool Alerted = false;


    public float movingSpeed=2;
    [SerializeField] public float AttackRate = 1.5f;
    [SerializeField] private float nextAttack;


    private EnemyPatrol EPRef;
    private LevelGeneration LGRef;


    void Start()
    {
        LGRef = GameObject.Find("LevelGeneration").GetComponent<LevelGeneration>();
        target = LGRef.Player.transform;
        EPRef = GetComponent<EnemyPatrol>();
        nextAttack = Time.time;
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
        if (Vector2.Distance(transform.position, target.transform.position) < DetectRange)
        {
            EPRef.canMove = false;
            MoveTowardsPlayer = true;
        }
        else
        {
            EPRef.canMove = true;
            MoveTowardsPlayer = false;
        }

        if (MoveTowardsPlayer)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < closeRange)
            {
                MoveTowardsPlayer = false;
                canAttack = true;
               
            }
            else
            {
                canAttack = false;
                StartCoroutine(waitforsec());
                if(Alerted)
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position ,movingSpeed*Time.deltaTime);
            }
        }
        if (canAttack  &  !MoveTowardsPlayer)
        { 
            StartCoroutine(waitforsec());

            Attack();
        }
    }
    void Attack()
    {

        if (Time.time > nextAttack)
        {
            Collider2D[]  hittedObj= Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayer);
            
            foreach (Collider2D Player in hittedObj)
            {
                Debug.Log("Hit Player");
            }
            nextAttack = Time.time + AttackRate;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    IEnumerator waitforsec()
    {
        yield return new WaitForSeconds(1);
        Alerted = true;
    }
}
