using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI healthText;

    public int health = 100;

    public int maxHealth = 100;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        healthText.text = health.ToString();
    }

    public void LoseHealth(int healthToReduce)
    {
        health -= healthToReduce;
        checkHealth();
    }
    public void checkHealth()
    {
        if(health <= 0) 
        {        
            Debug.Log("Has Muerto");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddHealth(int health)
    {
        if(this.health + health >= maxHealth)
        {
            this.health = 100;
        }
        else
        {
            this.health += health;
        }
    }
}
