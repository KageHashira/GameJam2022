using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    // public float ragePoints = 5f;
    private void OnEnable() 
    {
        
    }
    private void OnDisable() 
    {
       
    }
    private void Update() {
        // if(Input.GetKeyDown(KeyCode.D))
        // {
        //     Death();
        // }
    }
       public override void Death()
    {
        // need reference to ScriptableObject with rageValue
        // RageMeterController.Instance.AddRagePoints(ragePoints);
        //gameObject.SetActive(false);
    }
    public override void DamageTake(int hitPoints)
    {
        base.DamageTake(hitPoints);
        if(currentHP == 0) Death();
    }
}
