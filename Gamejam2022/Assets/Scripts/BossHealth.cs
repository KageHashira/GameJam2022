using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BossHealth : Health
{
    public static Action onDamageTaken;

    public override void DamageTake(int hitPoints)
    {
        base.DamageTake(hitPoints);
        onDamageTaken();

    }
}
