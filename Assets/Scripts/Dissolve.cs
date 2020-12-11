using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    static Material material;

    public static float fade = 1f;

    void Start()
    {
        // Get a reference to the material
        material = GetComponent<SpriteRenderer>().material;
    }

    public static IEnumerator Disappear(int repeatTimes)
    {
        int i = 0;

        while (i < repeatTimes)
        {
            fade -= Time.smoothDeltaTime;
            i++;

            if (fade <= 0f)
            {
                fade = 0f;
            }
            // Set the property
            material.SetFloat("_Fade", fade);
            yield return 0; // waits for a frame
        }
    }

    public static IEnumerator Reappear(int repeatTimes)
    {
        int i = 0;

        while (i < repeatTimes)
        {
            fade += Time.smoothDeltaTime;
            i++;

            if (fade >= 1f)
            {
                fade = 1f;
            }
            // Set the property
            material.SetFloat("_Fade", fade);
            yield return 0; // waits for a frame
        }
    }
}