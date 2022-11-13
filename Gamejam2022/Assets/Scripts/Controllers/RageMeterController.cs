using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class RageMeterController : MonoBehaviour
{
    public static RageMeterController Instance;
    private float currentRagePoints;
    [SerializeField] float maxRagePoints;
    public float CurrentRagePoints
    {
        
        get { return currentRagePoints; } 
        set
        {
            if (currentRagePoints == maxRagePoints){
                currentRagePoints = maxRagePoints;
            }
            else
                currentRagePoints = value;
            }
    }
    public float MaxRagePoints { 
        get{return maxRagePoints;}
        private set{maxRagePoints = value;}}
    public UnityEvent OnRageMeterFilled; 
    public bool rageMeterFilled = false;
    public static Action OnAddRagePoints;
    private void Awake() {
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }else
        {
            Instance = this;
        }
    }

    // If boss is not summoned,add ragePoints,update UI to current ragePoints value and if currentRagePoints is equal to maxRagePoints summon boss
    public void AddRagePoints(float ragePoints)
    {
        if(rageMeterFilled == false)
        {
            currentRagePoints+= ragePoints;
            
            if(OnRageMeterFilled != null) OnAddRagePoints();
            if(OnRageMeterFilled != null && currentRagePoints == maxRagePoints)
            {
                OnRageMeterFilled.Invoke();
                rageMeterFilled = true;    
            }
        }
    }
    
}
