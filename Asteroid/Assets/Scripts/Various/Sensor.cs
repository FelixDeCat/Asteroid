using System;
using UnityEngine;

public class Sensor : MonoBehaviour {

    public LayerMask layers;
    event Action<GameObject> Ev_Colision;

    Collider2D myc;

    public void Activate() { myc.enabled = true; }
    public void Deactivate() { myc.enabled = false; }

    private void Awake()
    {
        myc = gameObject.GetComponent<Collider2D>();
        myc.isTrigger = true;
    }

    public void SubscribeAction(Action<GameObject> ac) { Ev_Colision += ac; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & layers) != 0)
            Ev_Colision(collision.gameObject);
    }

}
