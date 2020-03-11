using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Objects/Weapons/Shotgun")]
public class Shotgun : Weapon
{
    public override void Fire(Camera cam)
    {
        Debug.Log("fire");
        //GameObject clone = Instantiate(bulletPrefab, spawn.transform.position, spawn.transform.rotation) as GameObject;
        //clone.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * 2000);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
