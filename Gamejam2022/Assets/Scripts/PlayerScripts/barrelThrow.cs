using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelThrow : MonoBehaviour
{
   
    public GameObject barrelPrefab;
    public float speed = 0.2f;
    public Transform firePoint;
    
    



    // Start is called before the first frame update
    public void barrelfire()
    {
        Instantiate(barrelPrefab, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
       /* if (speed > 0)
        {
            speed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        }
        else if (speed<0)
        {
            speed = 0;
        }*/
        
    }
}
