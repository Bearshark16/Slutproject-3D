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

    private void Awake()
    {
        fire.performed += OnFire;
        fire.canceled += OnFire;
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            rifle.isFire = true;
        }
        else
        {
            rifle.isFire = false;
        }
    }

    

    // Update is called once per frame
    void Update()
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

    private void FullAutoFire()
    {
        if (rifle.isFire)
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

    #region OnEnable&Disable
    private void OnEnable()
    {
        fire.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
    } 
    #endregion
}
