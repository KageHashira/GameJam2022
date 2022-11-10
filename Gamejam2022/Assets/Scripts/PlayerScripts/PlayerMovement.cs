using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    /*Player movement 
     * dash ability
     * tail render
     * shooting mechanic
     */

    public float speed = 6.2f;
    public Rigidbody2D RB;
    public Weapons Weapon;

    Vector2 movedirection;
    Vector2 mouseposition;

    private float activespeed;
    public float dashspeed;

    public float dashlength = 0.5f, dashcooldown = 1f;      //so that the player cant spam the dash

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

        if(Input.GetKeyDown(KeyCode.Space))                 //Dash ability
        {
            if(dashcoolcounter <= 0 && dashcounter <= 0)
            {
                activespeed = dashspeed;
                dashcounter = dashlength;
            }

            Tail.emitting = true;                           //player tail
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

        if(Input.GetMouseButtonDown(0))
        {
            Weapon.Fire();
        }

        //movedirection = new Vector2(movement.x, movement.y).normalized;
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    } 

    void FixedUpdate()
    {
        //RB.velocity = new Vector2(movedirection.x * speed, movedirection.y * speed);
        //RB.MovePosition(RB.position + movement * speed * Time.fixedDeltaTime);

        Vector2 aimDirection = mouseposition - RB.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        RB.rotation = aimAngle;
        

    }
}
