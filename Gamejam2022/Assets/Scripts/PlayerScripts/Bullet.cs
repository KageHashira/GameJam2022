using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timelimit = 1f;

    private void Start()
    {
        Destroy(gameObject, timelimit);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Barrel")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(55);

        }
        Destroy(gameObject);
    }
}
