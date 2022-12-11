using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject volume;

    public void Close() {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
