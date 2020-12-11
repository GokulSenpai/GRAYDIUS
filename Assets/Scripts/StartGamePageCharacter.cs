using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePageCharacter : MonoBehaviour
{
    Material material;

    float fade = 1f;

    void Start()
    {
        // Get a reference to the material
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fade -= Time.smoothDeltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
            }
            // Set the property
            material.SetFloat("_Fade", fade);
        }
        else
        {
            fade += Time.smoothDeltaTime;

            if (fade >= 1f)
            {
                fade = 1f;
            }
            // Set the property
            material.SetFloat("_Fade", fade);
        }
    }
}
