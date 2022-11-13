using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RulesPop : MonoBehaviour
{
    
    [SerializeField] UnityEvent onRulesPopAppear;
    [SerializeField] UnityEvent onRulesPopDisappear;

    private void OnEnable() {
        //If player runs game for the first time Rules will pop up and playerPref value will be set to 1 ,
        //which means that every time he play first level again ,rules won't pop up
        if(PlayerPrefs.GetInt("PlayedLevel1") == 0)
        {
           // Debug.Log(PlayerPrefs.GetInt("PlayedLevel1"));
            PlayerPrefs.SetInt("PlayedLevel1",1);
        }
        else
        {
           // Debug.Log(PlayerPrefs.GetInt("PlayedLevel1"));
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        RulesAppear();
    }

    public void RulesAppear()
    {
        onRulesPopAppear.Invoke();
    }
    public void RulesDisappear()
    {
        onRulesPopDisappear.Invoke();
    }

    //Remove it when GameManager will be created and unityEvent can catch stunning time from there.
    //Freeze or unfreeze time
    public void timeFreeze(int freeze)
    {
        if(freeze != 0 && freeze != 1)
        {
            Debug.LogWarning("freeze should be equal to 1 or 0 ");
            return;
        }
        Time.timeScale = freeze;
    }
}
