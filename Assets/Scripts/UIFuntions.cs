using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFuntions : MonoBehaviour
{
    [Header("String Variables")]
    /// <summary>
    /// Write the name the scene that you want to load
    /// </summary>
    [SerializeField] string sceneName;

    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPause = false; 

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Pause game
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Continue();
            } else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    } 
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
