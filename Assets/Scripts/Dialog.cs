using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Animator panelAnimator;

    public float audioWaitTime = 0f;

    public GameObject continueButton;
    public GameObject skipButton;
    public Animator textDisplayAnim;

    private void Start()
    {
        StartCoroutine(WaitForAudio(audioWaitTime));
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {
        textDisplayAnim.SetTrigger("Change");
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if(index == sentences.Length - 1)
        {
            textDisplay.text = "";
            skipButton.SetActive(false);
            continueButton.SetActive(false);
            StartCoroutine(SceneFadeAway());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    IEnumerator SceneFadeAway()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            CarMovement.carMove = true;
        }
        panelAnimator.SetTrigger("SceneFadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WaitForAudio(float audioWaitTime)
    {
        yield return new WaitForSeconds(audioWaitTime);
        StartCoroutine(Type());
    }
}
