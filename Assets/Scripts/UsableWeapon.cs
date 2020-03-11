using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsableWeapon : MonoBehaviour
{
    public GameObject pickUpVersion;
    protected GameObject playerObject;

    public void PickedUpBy(GameObject p)
    {
        playerObject = p;
    }
}
