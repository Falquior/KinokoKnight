using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("volume", 0.50f);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
