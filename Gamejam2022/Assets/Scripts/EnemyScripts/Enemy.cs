using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private int health = 100;
    private int currentHealth = 100;
    [SerializeField] private int attackDamage = 40;
    [SerializeField] private float attackCooldown = 1f;
    private float currentAttackTimer;
    [SerializeField] private float aggroRange = 10;
    [SerializeField] private float maxRoamRange = 10;
    [SerializeField] private float roamTime = 10f;
    private float currentTime;

    [Header("References")]
    public GameObject sprite;
    [SerializeField] private EnemyAbility[] abilties;
    [SerializeField] private StatusEffect statusEffect;
    [HideInInspector] public Transform player;
    private NavMeshAgent agent;

    private bool isAggro = false;

    private void Awake() {
        currentAttackTimer = attackCooldown;
        currentHealth = health;
        currentTime = roamTime;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (GameObject.FindWithTag("Player")) {
            player = GameObject.FindWithTag("Player").transform;
        } else {
            Debug.Log($"Player could not be found in {name}'s Enemy script. Make sure there is a player with the \"Player\" tag in the scene.");
        }
    }

    private void Update() {
        //Timers
        if (currentTime >= 0) currentTime -= Time.deltaTime;
        if (currentAttackTimer >= 0) currentAttackTimer -= Time.deltaTime;

        //Rotate sprite to look at its destination
        //TODO: Rotate sprite towards pathing rather than just end result
        if (agent.destination != null && agent.remainingDistance > agent.stoppingDistance) {
            float angle = Mathf.Atan2(agent.destination.y - transform.position.y, agent.destination.x - transform.position.x) * Mathf.Rad2Deg;
            sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        //Check if an ability is currently being animated before roaming/chasing
        foreach (EnemyAbility ability in abilties) {
            if (ability.isUsingAbility) {
                return;
            }
        }
        
        //If the player is within the AI's aggro range, targets the player. Otherwise, the AI will roam.
        if (player != null && Vector3.Distance(transform.position, player.position) <= aggroRange) {
            if (agent.destination != player.position) {
                isAggro = true;
                agent.SetDestination(player.position);
            }
        } else {
            if (currentTime <= 0) {
                //AI will get a random point within maxRoamRange, then find the nearest spot on the navmesh to that point and set it's destination there.
                isAggro = false;
                Vector3 randomPoint = (Random.insideUnitSphere * maxRoamRange) + transform.position;
                NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, maxRoamRange, 1);
                agent.SetDestination(hit.position);
                currentTime = roamTime;
            } else if (isAggro) {
                isAggro = false;
                agent.ResetPath();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (currentAttackTimer <= 0) {
            if (collision.gameObject.CompareTag("Player")) {
                //TODO: Implement health on the player to take damage similar to the comment below.
                //collision.gameObject.GetComponent<Health>().TakeDamage(attackDamage);

                if (statusEffect != null && Random.value <= statusEffect.chanceToTrigger) {
                    statusEffect.TriggerOnHit(collision.gameObject);
                }
            }
        }
    }

    private void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
