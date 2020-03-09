using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class ObjectInteraction : MonoBehaviour
{
    public InputAction pickUp;

    public Camera cam;
    public float range = 100f;

    public GameObject weaponLocation;

    public GameObject toolTip;
    public TextMeshProUGUI pickUpName;

    private bool isButtonPress;
    private GameObject newWp;
    private GameObject oldWp;

    private void Awake()
    {
        pickUp.performed += OnPickUp;
        pickUp.canceled += OnPickUp;
    }

    private void OnPickUp(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            isButtonPress = true;
        }
        else
        {
            isButtonPress = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Weapon")
            {
                toolTip.SetActive(true);
                pickUpName.text = hit.transform.name;
                if (isButtonPress)
                {
                    var local = hit.transform.position;
                    newWp = hit.transform.GetComponent<PickUp>().weaponPrefab;
                    foreach (Transform child in weaponLocation.transform)
                    {
                        oldWp = child.gameObject.GetComponent<UsableWeapon>().pickUpVersion;
                        Destroy(child.gameObject);
                    }
                    Destroy(hit.transform.gameObject);
                    Instantiate(oldWp, local, oldWp.transform.rotation);
                    GameObject x = Instantiate(newWp, weaponLocation.transform.position, weaponLocation.transform.rotation);
                    x.transform.SetParent(weaponLocation.transform);
                }
            }
            else
            {
                toolTip.SetActive(false);
            }
        }
    }

    #region OnEnable&Disable
    private void OnEnable()
    {
        pickUp.Enable();
    }

    private void OnDisable()
    {
        pickUp.Disable();
    } 
    #endregion
}
