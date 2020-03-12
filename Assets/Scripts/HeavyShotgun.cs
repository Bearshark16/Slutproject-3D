using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyShotgun : UsableWeapon
{
    [SerializeField]
    private Weapon shotgun;

    private float magazine;
    private float ammo;
    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    private void Awake()
    {
        magazine = shotgun.magazineSize;
        ammo = shotgun.ammoCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();
        playerObject.GetComponent<ObjectInteraction>().magazine.text = magazine.ToString();
        playerObject.GetComponent<ObjectInteraction>().ammoCapacity.text = ammo.ToString();


        if (keybindings.isFire && hasReleasedFire)
        {
            shotgun.Fire(playerObject.GetComponentInChildren<Camera>());
            hasReleasedFire = false;
        }
        else if (!keybindings.isFire)
        {
            hasReleasedFire = true;
        }

        if (keybindings.isReloading)
        {
            Reload();
        }
    }

    private void Reload()
    {
        if (magazine == 0)
        {
            if (ammo < shotgun.ammoCapacity)
            {
                magazine += ammo;
                ammo = 0;
            }
            else if (ammo == 0)
            {
                Debug.Log("Reserves are empty");
                return;
            }
            else
            {
                ammo -= shotgun.magazineSize;
                magazine += shotgun.magazineSize;
            }

        }
        else if (magazine != 0)
        {
            var value = shotgun.magazineSize - magazine;
            ammo -= value;
            magazine += value;
        }
    }
}
