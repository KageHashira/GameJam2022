using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    bool hasDied = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Death()
    {
        hasDied = true;
        if(onDeath!=null) onDeath();
       // throw new System.NotImplementedException();
    }
    public override void DamageTake(int hitPoints)
    {
        base.DamageTake(hitPoints);
         Debug.Log(currentHP);
        if(onDamageTaken!=null) onDamageTaken();
        if(hasDied == false && currentHP == 0) Death();
    }
}
