using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Objects/Weapons/Shotgun")]
public class Shotgun : Weapon
{
    public override void Fire(GameObject spawn)
    {
        Debug.Log("fire");
        GameObject clone = Instantiate(bulletPrefab, spawn.transform.position, spawn.transform.rotation) as GameObject;
        clone.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * 2000);
    }
}
