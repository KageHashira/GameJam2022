using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public abstract class EnemyAbility : MonoBehaviour {

    public float abilityCooldown = 2.5f;
    public float aggroRange = 4f;
    [HideInInspector] public bool isUsingAbility = false;

    public abstract void Start();
}