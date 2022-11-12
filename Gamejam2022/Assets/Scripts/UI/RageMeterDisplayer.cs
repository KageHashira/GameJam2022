using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RageMeterDisplayer : MonoBehaviour,IUpdateUI
{
    public Slider slider;
    private void OnEnable() {
        RageMeterController.OnAddRagePoints += UpdateUI;
    }
    private void OnDisable() {
        RageMeterController.OnAddRagePoints -= UpdateUI;
    }
    public void UpdateUI()
    {
        slider.value = Mathf.Clamp(RageMeterController.Instance.CurrentRagePoints/RageMeterController.Instance.MaxRagePoints,0,1);
    }
}
