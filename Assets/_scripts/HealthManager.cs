using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int playerHealth;

    //Text text;

    private LevelManager levelManager;

    public Slider healthBar;

    public bool notKilled;

    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Slider>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        notKilled = true;
    }
	
	// Update is called once per frame
	void Update () {

        if(playerHealth <=0 && notKilled)
        {
            //should be resetting the player health after respawning
            playerHealth = 0;
            levelManager.RespawnPlayer();
            notKilled = false;
        }

        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }

        //text.text = "" + playerHealth;
        healthBar.value = playerHealth;
	}

    //method to damage the player and reduce health
    public static void damagePlayer(int damageAmount)
    {
        playerHealth -= damageAmount;

    }

    public void resetHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
