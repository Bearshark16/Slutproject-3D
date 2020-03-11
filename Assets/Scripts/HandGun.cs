using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandGun : UsableWeapon
{
    [SerializeField]
    private Weapon pistol;

    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();

        if (keybindings.isFire && hasReleasedFire)
        {
            pistol.Fire(playerObject.GetComponentInChildren<Camera>());
            hasReleasedFire = false;
        }
        else if (!keybindings.isFire)
        {
            hasReleasedFire = true;
        }
    }
}
