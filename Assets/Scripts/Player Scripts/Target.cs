using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Target : NetworkBehaviour
{
    public float healthPoints = 100f;
    public TextMeshProUGUI healthPointsUI;

    private void Update()
    {
        if(!isLocalPlayer) 
        {
            return;
        }

        if (healthPointsUI != null)
        {
            healthPointsUI.text = healthPoints.ToString(); 
        }    
    }

    public void Damage(float amount)
    {
        Debug.Log("hit");

        healthPoints = healthPoints - amount;
        if (healthPoints <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.Damage(10);
        }
        
    }
}
