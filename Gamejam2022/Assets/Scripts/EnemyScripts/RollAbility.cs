using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RollAbility : EnemyAbility {
    public float startupTime = 0.5f;
    public float chargeLength = 7f;

    public override void Start() {
        StartCoroutine(Roll());
    }

    IEnumerator Roll() {
        //Waits till player is in range to use ability
        while (Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<Enemy>().player.position) > aggroRange) {
            yield return null;
        }

        //Animation stops before charging
        isUsingAbility = true;
        Enemy enemyScript = gameObject.GetComponent<Enemy>();
        NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
        Vector3 playerPos = enemyScript.player.position;
        enemyScript.sprite.GetComponent<SpriteRenderer>().color = Color.yellow;
        float angle = Mathf.Atan2(agent.destination.y - gameObject.transform.position.y, agent.destination.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
        enemyScript.sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        agent.ResetPath();
        yield return new WaitForSeconds(startupTime);

        //Charges past the player until it hits a wall or reaches its charge length
        enemyScript.sprite.GetComponent<SpriteRenderer>().color = Color.red;
        Vector3 direction = playerPos - transform.position;
        Vector3 endPos = (direction / direction.magnitude) * chargeLength;

        if (agent.Raycast(endPos, out NavMeshHit hit)) {
            agent.SetDestination(hit.position);
        } else {
            agent.SetDestination(direction);
        }

        while (agent.pathPending) {
            yield return null;
        }

        //Waits till the enemy reaches the location before stopping
        while (agent.remainingDistance > agent.stoppingDistance) {
            yield return null;
        }
        enemyScript.sprite.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.25f, 0, 1);
        isUsingAbility = false;

        //Waits for the cooldown to be over before attempting to start the ability again
        yield return new WaitForSeconds(abilityCooldown);
        StartCoroutine(Roll());
    }
}
