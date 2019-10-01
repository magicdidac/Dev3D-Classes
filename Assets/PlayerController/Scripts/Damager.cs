using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField] protected int maxHealth = 100;
    [HideInInspector] public int health;
    [HideInInspector] protected GameManager gm;

    protected void Start()
    {
        health = maxHealth;

        gm = GameManager.instance;


        gm.uiController.SetHealth(health);
    }

    public virtual void GetDammage(int amount)
    {

        health -= amount;

        gm.uiController.SetHealth(health);

        if (health <= 0)
            Dead();

    }

    public void AddHealth(int ammount)
    {
        health += ammount;
        if (health > maxHealth)
            health = maxHealth;

        gm.uiController.SetHealth(health);
    }

    protected void Dead()
    {
        Debug.Log("DEAD: " + gameObject);
        GameManager.instance.uiController.Dead();
    }

    public bool HaveMaxHealth()
    {
        return health >= maxHealth;
    }

}
