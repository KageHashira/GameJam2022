using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : Health
{
    public static Action onDamageTaken;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(CurrentHP);
            DamageTake(20);
            Debug.Log(CurrentHP);

        }
    }
    public override void DamageTake(int hitPoints)
    {
        base.DamageTake(hitPoints);
        onDamageTaken();

    }
}
