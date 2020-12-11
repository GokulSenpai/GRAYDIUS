using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudioSetB : MonoBehaviour
{
    DontDestroyAudioSetB instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}