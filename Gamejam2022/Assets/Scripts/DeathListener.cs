using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DeathListener : MonoBehaviour
{
    public static int deathCount = 0;
    [SerializeField] Health health;
    public UnityEvent onDeath;

    public void increaseAmount()
    {
        deathCount += 1;
        onDeath.Invoke();
    }
    private void OnEnable() {
        health.onDeath += increaseAmount;
    }
    private void OnDisable() {
        health.onDeath -= increaseAmount;
        
    }
}
