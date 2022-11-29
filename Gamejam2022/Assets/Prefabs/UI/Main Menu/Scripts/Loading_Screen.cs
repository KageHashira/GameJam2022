using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Screen : MonoBehaviour
{
    private Slider slider;
    private ParticleSystem particleSys;
    private Level_Select level;
    public GameObject add;

    private float targetProgress = 0;
    public float fillSpeed = 0.25f;
    private float blah = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        level = add.GetComponent<Level_Select>();
        particleSys = GameObject.Find("Particles").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        incrementProgress(0.75f);
    }

    void Update()
    {
        if (slider.value < targetProgress) {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying) {
                particleSys.Play();
            }

        }
        
        else {
            particleSys.Stop();
            blah += Time.deltaTime;
            if (blah >= 2) {
                slider.value = 1;
            }            
        }

        if (slider.value == 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level.num);
        }
    }

    public void incrementProgress(float newProgress)
    {
        targetProgress = slider.value  + newProgress;
    }
}
