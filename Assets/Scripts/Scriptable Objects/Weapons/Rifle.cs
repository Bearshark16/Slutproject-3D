using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rifle", menuName = "Objects/Weapons/Rifle")]
public class Rifle : Weapon
{
    [SerializeField]
    public bool Burst;

    public override void Fire(GameObject spawn)
    {
        Debug.Log("fire");
        GameObject clone = Instantiate(bulletPrefab, spawn.transform.position, spawn.transform.rotation) as GameObject;
        clone.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * 2000);
    }
}
