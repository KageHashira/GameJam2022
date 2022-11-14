using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private float minSpawnTime = 1, maxSpawnTime = 10;
    private float currentTime = 10;

    [SerializeField] private Vector2 bottomLeftBound = new Vector2(-10, -10);
    [SerializeField] private Vector2 topRightBound = new Vector2(10, 10);

    [SerializeField] private GameObject[] enemyTypes = null;
    private List<GameObject> currentEnemyPool = new();


    private void Awake() {
        //There should only be one EnemyManager
        if (Instance != null && Instance != this) {
            Debug.LogError("An EnemyManager already exists when trying to instantiate one.");
            Destroy(this);
        } else {
            Instance = this;
        }

        //Add already existing enemies to the pool list
        Enemy[] existingEnemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in existingEnemies) {
            enemy.transform.SetParent(transform);
            currentEnemyPool.Add(enemy.gameObject);
        }

        currentTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update() {
        if(currentTime > 0) currentTime -= Time.deltaTime;

        //If the rage meter is not full, spawn a random enemy within the boundaries.
        if (currentTime <= 0 && RageMeterController.Instance.CurrentRagePoints != RageMeterController.Instance.MaxRagePoints && enemyTypes != null) {
            Vector3 spawnPoint = new Vector3(Random.Range(bottomLeftBound.x, topRightBound.x), Random.Range(bottomLeftBound.y, topRightBound.y), 0);
            NavMesh.SamplePosition(spawnPoint, out NavMeshHit hit, 100f, 1);
            if (hit.position.x < bottomLeftBound.x || hit.position.x > topRightBound.x || hit.position.y < bottomLeftBound.y || hit.position.y > topRightBound.y) return;

            GameObject inst = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], hit.position, Quaternion.identity);
            inst.transform.SetParent(transform);
            currentEnemyPool.Add(inst);
            currentTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
