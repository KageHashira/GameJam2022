using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public int ab = 0;
    public GameObject levels;
    public GameObject volume;
    public GameObject play1;
    public GameObject play2;
    public GameObject volume1;
    public GameObject volume2;
    public GameObject quit1;
    public GameObject quit2;

    public void VolumeMenu() {
        volume.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PlayButton() {
        levels.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Start() {
        Invoke("first", 1);
    }

    private void first() {
        play1.SetActive(true);
        Invoke("second", 1);
    }

    private void second() {
        volume1.SetActive(true);
        Invoke("third", 1);
    }

    private void third() {
        quit1.SetActive(true);
    }

    public void pb() {
        play2.SetActive(true);
    }

    public void vb() {
        volume2.SetActive(true);
    }

    public void qb() {
        quit2.SetActive(true);
    }

    public void pb2() {
        play2.SetActive(false);
    }

    public void vb2() {
        volume2.SetActive(false);
    }

    public void qb2() {
        quit2.SetActive(false);
    }
}
