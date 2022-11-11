using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : StatusEffect
{
    [SerializeField] private float stunDuration = 1f;

    public override void TriggerOnHit(GameObject player) {
        StartCoroutine(Stun(player));
    }

    IEnumerator Stun(GameObject player) {
        //TODO: Change this later to make sure it properly stuns the player
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(stunDuration);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
