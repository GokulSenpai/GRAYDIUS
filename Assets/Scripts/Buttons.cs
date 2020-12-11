using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnStartButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    public void OnSkipButtonPressIntro()
    {
        SceneManager.LoadScene(2);
    }

    public void OnSkipButtonPressOnTheWay()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSkipButtonPressCity()
    {
        SceneManager.LoadScene(4);
    }

    public void OnSkipButtonPressDungeonEntrance()
    {
        SceneManager.LoadScene(5);
    }
    
    public void OnSkipButtonPressLevelZero()
    {
        SceneManager.LoadScene(6);
    }
}
