using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{

    public override void Death()
    {
        throw new System.NotImplementedException();
    }
    public override void DamageTake(int hitPoints)
    {
        base.DamageTake(hitPoints);
        if(currentHP == 0) Death();
    }
    
}
