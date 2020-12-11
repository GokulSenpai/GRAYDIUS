using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    public float DestroyTime = 3f;

    private void Start()
    {
        Destroy(this.gameObject, DestroyTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")==true)
        {

        }
        else if (other.gameObject.CompareTag( "Enemy"))
        {
            Destroy(other.gameObject);
        }
        else{  Destroy(this.gameObject);}

    }
}
