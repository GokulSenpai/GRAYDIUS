using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LevelOneCounter : MonoBehaviour
{
   static Color defaultColour;
    static SpriteRenderer sr;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColour = new Color(0.13f, 0.13f, 0.13f, 0.90f);
    }

    public static void Counter()
    {
        count += 1;
        if (count == 7)
        {
            GameObject.Find("LevelZeroEndTimelineObject").GetComponent<PlayableDirector>().Play();
            // FADE --------------    LevelZeroFadeOut.LevelZeroFade();
            //GameObject.Find("Bird").GetComponent<SpriteRenderer>().enabled = true;
            //sr.color = defaultColour;
        }
        Debug.Log(count);
    }
}
