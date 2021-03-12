using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 0;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectibles"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth == 4)
        {
            int temp = PlayerPrefs.GetInt("lifeAmount");
            PlayerPrefs.SetInt("lifeAmount", temp+1);
            PlayerPrefs.Save();
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
    }
}
