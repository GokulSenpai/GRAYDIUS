using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    private Vector3 currentPos;
    public float Minmax=5f;
    private float timer = 3f;
    public float GivenTime = 3f;
    private bool dir=true;
    public float speed=0.2f;
    public enum EnemyType {shooter,melee };
    public  EnemyType type;

    private Vector3 Changedpos;

    public bool canMove=false;

    void Start()
    {
        currentPos = this.transform.position;
        Changedpos = currentPos;
        timer = GivenTime;
    }

    void Update()
    {
        if (canMove)
        {
            EnemyMovement();
        }
    }

  private void  EnemyMovement()
    {

        switch (type)
        {
            case EnemyType.shooter:
                if (dir)
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        Changedpos = new Vector3(0, Mathf.Lerp(currentPos.y - Minmax, currentPos.y + Minmax, currentPos.y), 0) * speed * Time.deltaTime;
                        transform.position += Changedpos;
                    }
                    if (timer < 0)
                    {
                        timer = GivenTime;
                        dir = false;
                    }
                }
                else
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        Changedpos = new Vector3(0, Mathf.Lerp(currentPos.y - Minmax, currentPos.y + Minmax, currentPos.y), 0) * speed * Time.deltaTime;
                        transform.position -= Changedpos;
                    }
                    if (timer < 0)
                    {
                        timer = GivenTime;
                        dir = true;
                    }
                }
                break;
            case EnemyType.melee:
                if (dir)
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        Changedpos = new Vector3( Mathf.Lerp(currentPos.x - Minmax, currentPos.x + Minmax, currentPos.x),0, 0) * speed * Time.deltaTime;
                        transform.position += Changedpos;
                    }
                    if (timer < 0)
                    {
                        timer = GivenTime;
                        dir = false;
                    }
                }
                else
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        Changedpos = new Vector3( Mathf.Lerp(currentPos.x - Minmax, currentPos.x + Minmax, currentPos.x),0, 0) * speed * Time.deltaTime;
                        transform.position -= Changedpos;
                    }
                    if (timer < 0)
                    {
                        timer = GivenTime;
                        dir = true;
                    }
                }
                break;
            default:
                break;
        }
    }
        
       
}

