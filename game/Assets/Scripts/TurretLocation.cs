using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLocation : MonoBehaviour
{
    
    public bool hasTower= false;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateTurret();
        }
        
    }


    private void CreateTurret()
    {
        if (!hasTower)
        {
            FindObjectOfType<TowerFactory>().CreateTower(this);
        }
        else
        {
            Debug.Log("Can't place another tower here");
        }
    }

}
