using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectToBoss : MonoBehaviour
{
    private bool GotoBoss=false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GotoBoss)
        {
            //SceneManager.LoadScene.Index(2);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GotoBoss = true;

        }
    }
}
