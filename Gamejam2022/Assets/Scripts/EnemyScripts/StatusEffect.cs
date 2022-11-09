using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public abstract class StatusEffect : MonoBehaviour
{
    //chanceToTrigger float is directly equivalent to between 0 and 1 of its percentage chance of triggering. For example, 0.40 means a 40% chance of triggering.
    public float chanceToTrigger = 0.40f;

    public abstract void TriggerOnHit(GameObject player);
}
