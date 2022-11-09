using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6.2f;
    public Rigidbody2D RB;

    private float activespeed;
    public float dashspeed;

    public float dashlength = 0.5f, dashcooldown = 1f;

    private float dashcounter;
    private float dashcoolcounter;

    [SerializeField] private TrailRenderer Tail;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        activespeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        RB.velocity = movement * activespeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashcoolcounter <= 0 && dashcounter <= 0)
            {
                activespeed = dashspeed;
                dashcounter = dashlength;
            }

            Tail.emitting = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Tail.emitting = false;
        }

        if(dashcounter > 0)
        {
            dashcounter -= Time.deltaTime;

            if(dashcounter <= 0)
            {
                activespeed = speed;
                dashcoolcounter = dashcooldown;
            }
        }

        if(dashcoolcounter > 0)
        {
            dashcoolcounter -= Time.deltaTime;
        }
    }

    /*void FixedUpdate()
    {
        RB.MovePosition(RB.position + movement * speed * Time.fixedDeltaTime);
    }*/
}
