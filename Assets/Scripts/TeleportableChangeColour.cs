using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportableChangeColour : MonoBehaviour
{
    Color defaultColour;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            if (sr.color != Color.white)
            {
                sr.color = Color.white;
                LevelOneCounter.Counter();
            }
        }
    }
}
