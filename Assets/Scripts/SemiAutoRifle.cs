using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SemiAutoRifle : UsableWeapon
{
    [SerializeField]
    protected InputAction fire;
    [SerializeField]
    private Rifle rifle;
    [SerializeField]
    private GameObject spawn;

    private bool hasReleasedFire = true;
    private Keybindings keybindings;

    // Update is called once per frame
    void Update()
    {
        keybindings = playerObject.GetComponent<Keybindings>();

        if (rifle.Burst)
        {
            BurstFire(); 
        }
        else
        {
            FullAutoFire();
        }
    }

    private void FullAutoFire()
    {
        if (keybindings.isFire)
        {
            rifle.Fire(playerObject.GetComponentInChildren<Camera>());
        }
    }

    private void BurstFire()
    {
        if (Keybindings.instance.isFire && hasReleasedFire)
        {
            for (int i = 0; i < 3; i++)
            {
                rifle.Fire(playerObject.GetComponentInChildren<Camera>()); 
            }
            hasReleasedFire = false;
        }
        else if (!Keybindings.instance.isFire)
        {
            hasReleasedFire = true;
        }
    }
}
