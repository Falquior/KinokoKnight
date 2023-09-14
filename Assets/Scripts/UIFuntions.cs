using System.Collections;
using System.Collections.Generic;
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

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // METHOD TO PAUSE GAME

    // METHOD TO ACTIVATED PAUSE MENU
}
