using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathDisplayer : MonoBehaviour,IUpdateUI
{
    [SerializeField] TMP_Text deathCounterText;
    public void UpdateUI()
    {
        deathCounterText.text = DeathListener.deathCount.ToString();
    }
}
