using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Networking;

public class ObjectInteraction : NetworkBehaviour
{
    public Camera cam;
    public float range = 100f;

    public GameObject weaponLocation;
    public GameObject toolTip;
    public TextMeshProUGUI pickUpName;
    public TextMeshProUGUI magazine;
    public TextMeshProUGUI ammoCapacity;

    private GameObject newWp;
    private GameObject oldWp;
    private Keybindings keybindings;

    private void Awake() 
    {
        keybindings = this.GetComponent<Keybindings>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer) 
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Weapon")
            {
                toolTip.SetActive(true);
                pickUpName.text = hit.transform.name;
                Debug.Log(hit.transform.name.IndexOf("(clone)"));
                if (keybindings.isInteracting)
                {
                    var local = hit.transform.position;
                    newWp = hit.transform.GetComponent<PickUp>().weaponPrefab;
                    foreach (Transform child in weaponLocation.transform)
                    {
                        oldWp = child.gameObject.GetComponent<UsableWeapon>().pickUpVersion;
                        Destroy(child.gameObject);
                    }
                    if (oldWp)
                    {
                        Instantiate(oldWp, local, oldWp.transform.rotation);
                    }
                    Destroy(hit.transform.gameObject);
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
