using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    BulletHandlerExample bulletHandle;

    public GameObject bullet_model;
    public Transform bullet_parent;

   

    private void Awake()
    {
        bulletHandle = new BulletHandlerExample(transform.position, bullet_model, bullet_parent, 5, 10, 10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bulletHandle.GetObj();
        }
    }
}
