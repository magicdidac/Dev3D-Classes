using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField] protected int maxHealth = 100;
    [HideInInspector] protected int health;
    [SerializeField] protected UIController uiController = null;

    protected void Start()
    {
        health = maxHealth;
        uiController.SetHealth(health);
    }

    public void GetDammage(int amount)
    {
        health -= amount;

        uiController.SetHealth(health);

        if (health <= 0)
            Dead();

    }

    public void GetHealth(int ammount)
    {
        health += ammount;
        if (health > maxHealth)
            health = maxHealth;

        uiController.SetHealth(health);
    }

    protected void Dead()
    {
        health = 0;
        Debug.Log("DEAD: " + gameObject);
    }

}
