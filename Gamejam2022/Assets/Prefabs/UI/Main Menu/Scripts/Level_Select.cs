using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{
    public GameObject loading;

    public GameObject menu;

    public int num;

    public void first() {
        num = 1;
        loading.SetActive(true);
        gameObject.SetActive(false);
    }

    public void second() {
        num = 2;
        loading.SetActive(true);
        gameObject.SetActive(false);
    }

    public void third() {
        num = 3;
        loading.SetActive(true);
        gameObject.SetActive(false);
    }

    public void back() {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
