using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireforce = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireforce, ForceMode2D.Impulse);
    }

    public void SetBulletPrefab(GameObject newBullet)
    {
        bulletPrefab = newBullet;
    }
}
