using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public AudioSource buttonAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            buttonAudio.Play();
            Time.timeScale = 0f;
            AudioListener.pause = true;
            buttonAudio.ignoreListenerPause = true;
        }
    }
    
    public void OnResumeButtonPress()
    {
        Time.timeScale = 1f;
        buttonAudio.Play();
        StartCoroutine(WaitForResume());
    }
    
    public void OnQuitButtonPress()
    {
        Debug.Log("Application Quit");
        buttonAudio.Play();
        Application.Quit();
    }

    private IEnumerator WaitForResume()
    {
        yield return new WaitForSeconds(0.14f);
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        buttonAudio.ignoreListenerPause = false;
    }
    
}
