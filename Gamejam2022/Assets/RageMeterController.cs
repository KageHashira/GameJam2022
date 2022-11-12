using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Action OnRageMeterFilled; 
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
    public void AddRagePoints(float ragePoints)
    {
        currentRagePoints+= ragePoints;
        if(OnRageMeterFilled != null) OnAddRagePoints();
        if(OnRageMeterFilled != null && currentRagePoints == maxRagePoints) OnRageMeterFilled();
    }
    
}
