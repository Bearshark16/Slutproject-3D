using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class ObjectInteraction : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;

    public GameObject weaponLocation;

    public GameObject toolTip;
    public TextMeshProUGUI pickUpName;

    private GameObject newWp;
    private GameObject oldWp;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Weapon")
            {
                toolTip.SetActive(true);
                pickUpName.text = hit.transform.name;
                if (Keybindings.instance.isInteracting)
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

                    x.GetComponent<UsableWeapon>().PickedUpBy(this.gameObject);
                }
            }
            else
            {
                toolTip.SetActive(false);
            }
        }
    }
}
