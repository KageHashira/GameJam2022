using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    public Slider slider;

    void Start() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else {
            Load();
        }
    }

    public void changeV() {
        AudioListener.volume = slider.value;
    }

    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }

    private void Load() {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
