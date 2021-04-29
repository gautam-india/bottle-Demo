using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelManager : MonoBehaviour
{
    private PlayerProgress playerProgress;
    private int level;

    private void Awake()
    {

        playerProgress = FindObjectOfType<PlayerProgress>();
       
    }


    public void retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Kitchen");
    }

    public void backTomain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void victory()
    {
        Time.timeScale = 1f;
        playerProgress._playerProgress.levelUnlocked[level] = true;
        SceneManager.LoadScene("MainMenu");
    }

}
