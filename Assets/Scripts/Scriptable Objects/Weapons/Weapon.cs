﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public float damage;
    public float range;
    public float magazineSize;
    public float ammoCapacity;

    public virtual void Fire(Camera cam)
    {
        Debug.Log("Fire");
    }
}
