using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthDisplayer : MonoBehaviour,IUpdateUI
{
    [SerializeField] Slider slider;
    private void OnEnable() 
    {
        PlayerHealth.onDamageTaken += UpdateUI;
    }
    private void OnDisable() 
    {
        PlayerHealth.onDamageTaken -= UpdateUI;
    }
    public void UpdateUI()
    {
       slider.value = Mathf.Clamp(PlayerHealth.CurrentHP/PlayerHealth.MaxHP,0,1);
    }
}
