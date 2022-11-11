using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour,IDamage
{
    public static float CurrentHP{get; private set;}
    public static float MaxHP{get; private set;}
    [SerializeField] float maxHP;
    private void Awake() {
        CurrentHP = maxHP;
        MaxHP = maxHP;
    }
    //Reducing currentHP by hitPoints parameter and call onDamageTaken action. 
    public virtual void DamageTake(int hitPoints)
    {
        CurrentHP -= hitPoints;
    }
}
