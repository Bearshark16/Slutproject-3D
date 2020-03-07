using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SemiAutoRifle : MonoBehaviour
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
            rifle.Fire(spawn);
        }
    }

    private void BurstFire()
    {
        if (rifle.isFire && hasReleasedFire)
        {
            for (int i = 0; i < 3; i++)
            {
                rifle.Fire(spawn); 
            }
            hasReleasedFire = false;
        }
        else if (!rifle.isFire)
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
