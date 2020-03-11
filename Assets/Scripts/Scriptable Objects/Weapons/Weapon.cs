using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : ScriptableObject
{
    
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int Range;
    [SerializeField]
    protected int magazineSize;
    [SerializeField]
    protected GameObject bulletPrefab;

    public virtual void Fire(Camera cam)
    {
        Debug.Log("Fire");
    }
}
