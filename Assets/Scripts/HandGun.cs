using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandGun : UsableWeapon
{
    [SerializeField]
    protected InputAction fire;
    [SerializeField]
    private Weapon pistol;
    [SerializeField]
    private GameObject spawn;

    private bool hasReleasedFire = true;
    public Camera cam;

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
            pistol.isFire = true;
        }
        else
        {
            pistol.isFire = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        cam = transform.parent.transform.parent.gameObject.GetComponent<Camera>();
        

        if (pistol.isFire && hasReleasedFire)
        {
            pistol.Fire(spawn);
            hasReleasedFire = false;
        }
        else if (!pistol.isFire)
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
