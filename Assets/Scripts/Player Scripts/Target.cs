using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float healthPoints = 100f;
    public TextMeshProUGUI healthPointsUI;

    private void Update()
    {
        if (healthPointsUI != null)
        {
            healthPointsUI.text = healthPoints.ToString(); 
        }    
    }

    public void Damage(float amount)
    {
        Debug.Log("hit");

        healthPoints -= amount;
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
        collision.gameObject.GetComponent<Target>().Damage(10);
    }
}
