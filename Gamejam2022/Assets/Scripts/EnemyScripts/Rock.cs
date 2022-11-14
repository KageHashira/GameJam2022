using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [HideInInspector] public float speed = 1;
    [HideInInspector] public float lifespan = 10;
    private float currentLifetime = 10;

    private void Awake() {
        currentLifetime = lifespan;
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;

        if (currentLifetime <= 0) {
            Destroy(gameObject);
        }

        transform.position = transform.position + speed * transform.up * 0.001f;
    }
}
