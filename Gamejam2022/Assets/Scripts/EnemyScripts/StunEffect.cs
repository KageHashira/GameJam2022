using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : StatusEffect
{
    [SerializeField] private float stunDuration;

    public override void TriggerOnHit(GameObject player) {
        //TODO: stun the player for stunDuration
    }
}
