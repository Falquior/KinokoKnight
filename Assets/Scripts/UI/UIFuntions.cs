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
    [SerializeField] GameObject optionsMenu;
    public static bool GameIsPause = false;

    CharacterCombat charActive;


    private void Start()
    {
        charActive = FindAnyObjectByType<CharacterCombat>();
    }
    public void ChangeScene()
    {
        Time.timeScale = 1f;
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
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        charActive.swordActive = true;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    } 
    void Pause()
    {
        charActive.swordActive = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}