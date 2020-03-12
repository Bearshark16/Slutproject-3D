using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandGun : UsableWeapon
{
    [SerializeField]
    private Weapon pistol;

    private float magazine;
    private float ammo;
    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    private void Awake()
    {
        magazine = pistol.magazineSize;
        ammo = pistol.ammoCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();
        playerObject.GetComponent<ObjectInteraction>().magazine.text = magazine.ToString();
        playerObject.GetComponent<ObjectInteraction>().ammoCapacity.text = ammo.ToString();

        if (keybindings.isFire && hasReleasedFire)
        {
            pistol.Fire(playerObject.GetComponentInChildren<Camera>());
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
            if (ammo < pistol.ammoCapacity)
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
                ammo -= pistol.magazineSize;
                magazine += pistol.magazineSize;
            }

        }
        else if (magazine != 0)
        {
            var value = pistol.magazineSize - magazine;
            ammo -= value;
            magazine += value;
        }
    }
}
