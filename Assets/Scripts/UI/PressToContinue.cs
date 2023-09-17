using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PressToContinue : MonoBehaviour
{
    [Tooltip("Name of the scene that will be opened when a key is pressed.")]
    [SerializeField] private string sceneToLoad = "MainMenu";

    // True after enabled during 5 seconds
    private bool fiveSecondsPassed = false;

    // Fade speef for press to continue text.
    public float fadeSpeed = 2.0f;
    [SerializeField] private TextMeshProUGUI textToFade;
    private bool fadingIn = true;
    private float currentAlpha = 0f;
    [Header("UI Elements")]
    [Tooltip("PLayer's Life game object to hide when boss defeated.")]
    [SerializeField] private GameObject playerLife;
    [Tooltip("Boss health bar game object to hide when boss defeated.")]
    [SerializeField] private GameObject enemyHealthBar;



    private void Update()
    {
        if (fiveSecondsPassed)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(sceneToLoad);
            
            currentAlpha = textToFade.alpha;
            // Calculates new alpha.
            currentAlpha += (fadingIn ? 1 : -1) * fadeSpeed * Time.deltaTime;
            // Limits alpha between 0 and 1.
            currentAlpha = Mathf.Clamp01(currentAlpha);
            // updates alpha in text.
            textToFade.alpha = currentAlpha;
            // Toggles between fading in and out.
            if (currentAlpha <= 0.0f || currentAlpha >= 1.0f)
                fadingIn = !fadingIn;
        }
    }

    private void OnEnable()
    {
        textToFade.enabled = false;
        playerLife.SetActive(false);
        enemyHealthBar.SetActive(false);
        StartCoroutine(WaitToContinue());
    }

    private IEnumerator WaitToContinue()
    {
        yield return new WaitForSeconds(5);
        fiveSecondsPassed = true;
        textToFade.enabled = true;
    }

}
