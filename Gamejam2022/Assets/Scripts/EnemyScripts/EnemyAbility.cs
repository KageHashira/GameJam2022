using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public abstract class EnemyAbility : MonoBehaviour {

    public float abilityCooldown = 2.5f;
    public float aggroRange = 4f;
    [HideInInspector] public bool isUsingAbility = false;

    [HideInInspector] public Enemy enemyScript = null;
    [HideInInspector] public NavMeshAgent agent = null;

    public virtual void Start() {
        enemyScript = gameObject.GetComponent<Enemy>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(Ability());
    }

    public abstract IEnumerator Ability();
}