using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject bullet_model;
    public Transform bullet_parent;

    BulletHandler bulletHandle;

    

    public UI_Life obs_ui_life;
    LifeManager lifemanager;

    public AudioClip clip_lose_life;
    SoundHandler obs_sound_life;

    public Rigidbody2D rb2d;
    ScreenLimiter screenlimits;

    private void Start()
    {
        bulletHandle = new BulletHandler(transform.position, bullet_model, bullet_parent,  5, 10, 10);
        screenlimits = new ScreenLimiter(transform);
        lifemanager = new LifeManager(3, obs_ui_life, new SoundHandler(clip_lose_life));
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
