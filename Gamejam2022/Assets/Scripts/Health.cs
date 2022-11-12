using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    protected float currentHP;
    [SerializeField] protected float maxHP;
    public float CurrentHP
    {
        get { return currentHP; } 
        set
        {
            if (currentHP == 0){
                currentHP = 0;
            }
            else
                currentHP = value;
        }
    }
    public float MaxHP{
        get { return maxHP; } 
        private set { maxHP = value;}
    }
    
    public  Action onDamageTaken;
    public  Action onDeath;

    private void OnEnable() {
        currentHP = maxHP;
    }
    public abstract void Death();
    //Reducing currentHP by hitPoints parameter and call onDamageTaken action. 
    public virtual void DamageTake(int hitPoints)
    {
        currentHP -= hitPoints;
        Debug.Log(currentHP);
       
    }
}
