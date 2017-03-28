using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : CuboAbstracto {

    protected override void Shoot()
    {
        print("se hundió Fire, desde " + gameObject.name);
    }
}
