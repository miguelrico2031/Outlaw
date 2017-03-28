using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CuboAbstracto : MonoBehaviour
{

    protected abstract void Shoot();

	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        Shoot();
	    }
	}
}
