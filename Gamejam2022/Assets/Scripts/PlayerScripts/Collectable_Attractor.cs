using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Attractor : MonoBehaviour
{
    public float Attractorspeed;

    // Update is called once per frame
    //void Update()
    //{
    //    if(CompareTag("Player"))
    //    {

    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, Attractorspeed * Time.deltaTime);

            if(transform.position == collision.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
