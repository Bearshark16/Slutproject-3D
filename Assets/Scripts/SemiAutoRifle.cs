﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SemiAutoRifle : UsableWeapon
{
    [SerializeField]
    private Rifle rifle;
    [SerializeField]
    private GameObject spawn;

    private float magazine;
    private float ammo;
    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    private void Awake() 
    {
        magazine = rifle.magazineSize;
        ammo = rifle.ammoCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();
        playerObject.GetComponent<ObjectInteraction>().magazine.text = magazine.ToString();
        playerObject.GetComponent<ObjectInteraction>().ammoCapacity.text = ammo.ToString();

        if (magazine != 0)
        {
            if (rifle.Burst)
            {
                BurstFire();
            }
            else
            {
                FullAutoFire();
            }
        }

        if (keybindings.isReloading) 
        {
            if (magazine == 0) 
            {
                ammo -= rifle.magazineSize;
                magazine += rifle.magazineSize;
            }
            else if (magazine != 0) 
            {
                var value = rifle.magazineSize - magazine;
                ammo -= value;
                magazine += value;
            }
        }
    }

    private void FullAutoFire()
    {
        if (keybindings.isFire)
        {
            rifle.Fire(playerObject.GetComponentInChildren<Camera>());
            magazine--;
        }
    }

    private void BurstFire()
    {
        if (keybindings.isFire && hasReleasedFire)
        {
            for (int i = 0; i < 3; i++)
            {
                rifle.Fire(playerObject.GetComponentInChildren<Camera>()); 
                magazine--;
            }
            hasReleasedFire = false;
        }
        else if (!keybindings.isFire)
        {
            hasReleasedFire = true;
        }
    }
}
