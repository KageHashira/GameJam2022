using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplayer : MonoBehaviour,IUpdateUI
{
    [SerializeField] Slider sliderToUpdate;
    [SerializeField] Health health;
    private void OnEnable() 
    {
        health.onDamageTaken += UpdateUI;
    }
    private void OnDisable() 
    {
        health.onDamageTaken -= UpdateUI;
    }
    
    public void UpdateUI()
    {
       sliderToUpdate.value = Mathf.Clamp(health.CurrentHP/health.MaxHP,0,1);
    }
}
