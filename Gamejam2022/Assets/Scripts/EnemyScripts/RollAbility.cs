using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RollAbility : EnemyAbility {
    public float startupTime = 0.5f;
    public float chargeLength = 7f;

    public override IEnumerator Ability() {
        //Waits till player is in range to use ability
        while (Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<Enemy>().player.position) > aggroRange) {
            yield return null;
        }

        //Animation stops before charging
        isUsingAbility = true;
        Vector3 playerPos = enemyScript.player.position;
        //TODO: Set sprite to initial charging animation here
        float angle = Vector2.SignedAngle(transform.up, playerPos - transform.position);
        enemyScript.LookTowards(angle);
        agent.ResetPath();
        yield return new WaitForSeconds(startupTime);

        //TODO: Set sprite to charging animation here
        Vector3 startPos = transform.position;
        startPos.z = 0;
        Vector3 direction = (playerPos - startPos).normalized;

        //Charges past the player until it hits a wall or reaches its charge length
        int layerMask = 1 << 3; //Raycast should only be able to hit walls(index 3)
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, chargeLength, layerMask);
        if (hit) {
            agent.SetDestination(hit.point);
        } else {
            agent.SetDestination(direction * chargeLength);
        }

        while (agent.pathPending) {
            yield return null;
        }

        //Waits till the enemy reaches the location before stopping
        while (agent.remainingDistance > agent.stoppingDistance) {
            yield return null;
        }
        isUsingAbility = false;

        //Waits for the cooldown to be over before attempting to start the ability again
        yield return new WaitForSeconds(abilityCooldown);
        StartCoroutine(Ability());
    }
}
