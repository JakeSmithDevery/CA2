using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float h, v;
    Vector3 mouseWorldPosition;

    public Bullet BulletPrefab;
    public Transform BulletSpawnPoint;

    public int Ammo = 20;
    public int MaxAmmo = 20;
    public float RegenerateAmmoTime = 2;
    public int AmmoRegenAmount = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        InvokeRepeating("RegenerateAmmo",RegenerateAmmoTime,RegenerateAmmoTime);
        base.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        transform.up = mouseWorldPosition - transform.position;

        if(Input.GetButton("Fire2"))
        {
            SetState(CharacterState.Attack);

            if (Input.GetButtonDown("Fire1"))
            {
                if(Ammo > 1)
                {
                    Fire();
                }
            }
        }
        else
        {
            SetState(CharacterState.Idle);
        }
    }

    private void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3(h,v,0) * movementSpeed * Time.deltaTime);
    }

    void Fire()
    {
        Bullet inst = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
        inst.SetDirection(transform.up);
        Ammo--;
    }   
    
    void RegenerateAmmo()
    {
        if (Ammo < MaxAmmo)
        {
            Ammo = Ammo + AmmoRegenAmount;
        }
    }
}
