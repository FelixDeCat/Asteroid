using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Tools.Sound;
using System;

public class Bomb : MonoBehaviour {

    Rigidbody2D rb2D;

    bool onTheAir = false;

    public float timeToExplode = 3;
    public float bombSize = 0.4f;

    public AudioClip clip_explode;
    AudioSource as_explode;

    ScreenLimiter screenlimiter;

    public List<Renderer> renders;

    public Light lux;

    public Animator anim;
    public SpriteRenderer sp;

    public Collider2D colexplosion;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        as_explode = ASourceCreator.Create2DSource(clip_explode, "explode");
    }

    private void Start()
    {
        DeactivateBomb();
        DeactivateExplosion();

        screenlimiter = new ScreenLimiter(transform);
        var exp = anim.GetBehaviour<ExplosionStateBehaviour>();
        exp.AddListener_OnExplosion(OnExplosionAnimationEnd);
    }

    private void Update() { screenlimiter.Manual_Update(); }

    void ActivateBomb() {
        transform.localScale = new Vector3(bombSize,bombSize,bombSize);
        renders.ForEach(x => x.enabled = true);
    }
    void DeactivateBomb() { renders.ForEach(x => x.enabled = false); }
    void ActivateExplosion()
    {
        DeactivateBomb();
        lux.enabled = true;
        sp.enabled = true;
        colexplosion.enabled = true;
        anim.Play("Explosion");
        as_explode.Play();
    }
    void DeactivateExplosion()
    {
        lux.enabled = false;
        sp.enabled = false;
        colexplosion.enabled = false;
    }

    public void Launch(Vector2 position, Vector2 direction, float force)
    {
        if (onTheAir) return;
        onTheAir = true;
        ActivateBomb();
        transform.position = position;
        transform.up = direction;
        var result = transform.up.normalized * force;
        rb2D.AddForce(result, ForceMode2D.Impulse);
        Invoke("Explode", timeToExplode);
    }

    //For Explosion

    void OnExplosionAnimationEnd()
    {
        DeactivateExplosion();
        onTheAir = false;
    }

    public void Explode()
    {
        ActivateExplosion();
    }
}
