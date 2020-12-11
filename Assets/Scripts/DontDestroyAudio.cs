using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    public Animator animator;
    DontDestroyAudio instance = null;
    private static readonly int MusicZero = Animator.StringToHash("MusicZero");

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

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

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            animator.SetTrigger(MusicZero);
            Destroy(gameObject);
        }
    }
}
