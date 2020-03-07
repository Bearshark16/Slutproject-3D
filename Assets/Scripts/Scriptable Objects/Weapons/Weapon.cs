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

    protected int fireRate;
    [NonSerialized]
    public bool isFire;

    public virtual void Fire(GameObject spawn)
    {
        Debug.Log("Fire");
    }
}
