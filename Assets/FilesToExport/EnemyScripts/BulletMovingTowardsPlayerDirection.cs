using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovingTowardsPlayerDirection : MonoBehaviour
{
    private Transform target;
    private Vector2 direction;
    public float Bulletspeed;

    public Vector3 finalBulletSize;
    private Vector3 currentBulletSize;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = (target.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x, direction.y )* Bulletspeed * Time.deltaTime;

        finalBulletSize = new Vector3(0.75f, 0.75f, 1);

    }

    private void Update()
    {
        resize();
    }

    private  void resize()
    {
        currentBulletSize = rb.transform.localScale;
        if(rb.transform.localScale.x<finalBulletSize.x & rb.transform.localScale.y < finalBulletSize.y)
        {
            currentBulletSize.x += 0.01f;
            currentBulletSize.y += 0.01f;
            rb.transform.localScale = currentBulletSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player")| collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
       
    }
}
