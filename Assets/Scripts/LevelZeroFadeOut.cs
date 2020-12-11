using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelZeroFadeOut : MonoBehaviour
{
    public static LevelZeroFadeOut instance;
    static Animator panelAnimator;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        panelAnimator = GameObject.Find("Panel").GetComponent<Animator>();
    }

    public static void LevelZeroFade()
    {
        panelAnimator.SetTrigger("SceneFadeOut");
        instance.StartCoroutine(FadeCompletion());
    }

    static IEnumerator FadeCompletion()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
