using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Tooltip("Name of the scene that will be opened if try again button is pressed.")]
    [SerializeField] private string sceneName;

    private string mainMenuName = "MainMenu";
    [Tooltip("Health bar of the boss in the scene GameObject.")]
    [SerializeField] private GameObject bossLifeBar;
    [SerializeField] private GameObject characterLifeBar;

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuName);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        if (bossLifeBar != null)
            bossLifeBar.SetActive(false);
        if (characterLifeBar != null)
            characterLifeBar.SetActive(false);
    }
}
