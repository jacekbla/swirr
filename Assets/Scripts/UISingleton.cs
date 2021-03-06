﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISingleton : MonoBehaviour
{
    [SerializeField] 
    private Text healthLabel;

    [SerializeField]
    private Text gameOverLabel;

    [SerializeField]
    private Text bulletsLabel;

    [SerializeField]
    private Text magazinesLabel;

    // Start is called before the first frame update
    private static UISingleton instance = null;

    // Game Instance Singleton
    public static UISingleton Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        gameOverLabel.enabled = false;
        
    }

    public void setHealth(float health)
    {
        healthLabel.text = "Health: " + health.ToString();
    }

    public void setBullets(string bulletsInMagazine)
    {
        bulletsLabel.text = "Bullets: " + bulletsInMagazine;
    }

    public void setMagazines(string magazines){
        magazinesLabel.text = "Magazines: " + magazines;
    }
    public void showGameOver()
    {
        Debug.Log("gameOver");
        gameOverLabel.enabled = true;
    }
}
