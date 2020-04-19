using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Objects/Weapons/Shotgun")]
public class Shotgun : Weapon
{
    public override void Fire(Camera cam)
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("fire");
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damage(damage);
            }
        }
    }
}
