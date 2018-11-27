using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extensions;

public class PumpLauncher : GunBase {

    public Transform pointToShoot;
    public Bomb bomb;

    public override void OnPress()
    {
        bomb.Launch(pointToShoot.transform.position, pointToShoot.transform.up, 2);
    }

    public override void OnRelease()
    {
        //nada x ahora
    }
}
