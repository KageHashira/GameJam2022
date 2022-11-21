using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject Bullet1;
    [SerializeField] private GameObject Bullet2;
    

    private Weapons weaponscipt;
    private SpriteRenderer SR;

    private void Awake()
    {

        weaponscipt = transform.GetChild(0).GetComponent<Weapons>();

    }

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))        //Number 1 on keyboard
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))       //Number 2 on keyboard
        {
            SetWeapon(2);
        }
       
    }

    void SetWeapon(int WeaponID)
    {
        switch(WeaponID)
        {
            case 1:
                weaponscipt.SetBulletPrefab(Bullet1);
                ChancePlayerColor(Color.white);
                break;
            case 2:
                weaponscipt.SetBulletPrefab(Bullet2);
                ChancePlayerColor(Color.green);
                break;
            

        }
    }

    void ChancePlayerColor(Color c)
    {
        SR.color = c;
    }
}
