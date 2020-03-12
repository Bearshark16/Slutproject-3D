using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rifle", menuName = "Objects/Weapons/Rifle")]
public class Rifle : Weapon
{
    [SerializeField]
    public bool Burst;

    public override void Fire(Camera cam)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
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
