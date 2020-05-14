using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 5;
    private int healthDecrease = 1;
    [SerializeField] Image[] healthUIImages = new Image[5];

    void Start()
    {
        Array.Reverse(healthUIImages);
    }

    public void DecreaseHealth()
    {

        playerHealth -= healthDecrease;
        Debug.Log(playerHealth);
      
        healthUIImages[playerHealth].enabled = false;
        if(playerHealth <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        FindObjectOfType<SceneLoader>().EndGame();
    }
    
    
}

