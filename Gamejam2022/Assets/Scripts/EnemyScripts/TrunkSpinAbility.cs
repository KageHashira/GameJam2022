using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrunkSpinAbility : EnemyAbility
{
    [SerializeField] private float duration;
    [SerializeField] private float trunkDamage;
    [SerializeField] private float rockDamage;
    [SerializeField] private float startupTime;
    [SerializeField] private float fullSwings;
    [SerializeField] private float rocksPerFullSwing;
    [SerializeField] private float trunkSpeed;
    [SerializeField] private float rockSpeed;
    [SerializeField] private float rockLifespan;

    [SerializeField] private GameObject trunk;
    [SerializeField] private GameObject rock;

    public override IEnumerator Ability() {
        //Waits till player is in range to use ability
        while (Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<Enemy>().player.position) > aggroRange) {
            yield return null;
        }

        //Animation stops before charging
        isUsingAbility = true;
        float agentSpeed = agent.speed;
        agent.speed = 0;
        enemyScript.LookTowards(180f);
        agent.ResetPath();
        yield return new WaitForSeconds(startupTime);

        //Full swing trunk around throwing rocks in set increments and increasing.
        int currentRockAngle = 0;
        for (int i = 0; i < 360 * fullSwings; i++) {
            trunk.transform.rotation = Quaternion.Euler(0, 0, i % 360);

            if ((i + currentRockAngle) % (360/rocksPerFullSwing) == 0) {
                GameObject rockInst = Instantiate(rock, transform.position, trunk.transform.rotation);
                rockInst.GetComponent<Rock>().speed = rockSpeed;
                rockInst.GetComponent<Rock>().lifespan = rockLifespan;
                currentRockAngle++;
            }
            
            //TODO: make currentRockAngle increase after instantiate instead, maybe?
            if (i % 360 == 0) {
                currentRockAngle++;
            }
            yield return new WaitForSeconds(1f/trunkSpeed);
        }

        isUsingAbility = false;
        agent.speed = agentSpeed;

        //Waits for the cooldown to be over before attempting to start the ability again
        yield return new WaitForSeconds(abilityCooldown);
        StartCoroutine(Ability());
    }
}
