using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    List<Enemy> enemiesinradius = new List<Enemy>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemiesinradius.Add(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemiesinradius.Remove(other.GetComponent<Enemy>());
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < enemiesinradius.Count; i++)
        {
            enemiesinradius[i].TakeDamage(30);
        }
    }
}
