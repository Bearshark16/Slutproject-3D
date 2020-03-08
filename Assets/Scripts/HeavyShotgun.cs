using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyShotgun : UsableWeapon
{
    [SerializeField]
    protected InputAction fire;
    [SerializeField]
    private Weapon shotgun;
    [SerializeField]
    private GameObject spawnOne;
    [SerializeField]
    private GameObject spawnTwo;
    [SerializeField]
    private GameObject spawnThree;
    [SerializeField]
    private GameObject spawnFour;

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
            shotgun.isFire = true;
        }
        else
        {
            shotgun.isFire = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shotgun.isFire && hasReleasedFire)
        {
            shotgun.Fire(spawnOne);
            shotgun.Fire(spawnTwo);
            shotgun.Fire(spawnThree);
            shotgun.Fire(spawnFour);
            hasReleasedFire = false;
        }
        else if (!shotgun.isFire)
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
