using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    public GameObject bullet_model;
    public Transform bullet_parent;

    BulletHandler bulletHandle;
    public LifeManager lifemanager;

    public Rigidbody2D rb2d;
    ScreenLimits screenlimits;

    private void Awake()
    {
        bulletHandle = new BulletHandler(transform.position, bullet_model, bullet_parent,  5, 10, 10);
        screenlimits = new ScreenLimits(transform,OnRepositioning);

    }

    void OnRepositioning(Vector3 vector)
    {
        transform.position = vector;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) bulletHandle.Shoot();
        if (Input.GetKeyDown(KeyCode.R)) lifemanager.Hit(); 
        if (Input.GetKeyDown(KeyCode.T)) lifemanager.AddHealth(); 
        if (Input.GetKeyDown(KeyCode.Y)) lifemanager.IncreaseLife();

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(transform.up*10, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -5);
        }

        screenlimits.Manual_Update();
    }
}
