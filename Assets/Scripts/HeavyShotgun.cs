using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyShotgun : UsableWeapon
{
    [SerializeField]
    private Weapon shotgun;

    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();

        if (keybindings.isFire && hasReleasedFire)
        {
            shotgun.Fire(playerObject.GetComponentInChildren<Camera>());
            hasReleasedFire = false;
        }
        else if (!keybindings.isFire)
        {
            hasReleasedFire = true;
        }
    }
}
