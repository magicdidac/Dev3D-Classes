using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerWithShield : Damager
{

    [SerializeField] private int maxShield = 100;
    [HideInInspector] public int shield;

    private new void Start()
    {
        base.Start();
        shield = 0;
        gm.uiController.SetShield(shield);
    }

    public void AddShield(int amount)
    {
        shield += amount;
        if (shield > maxShield)
            shield = maxShield;

        gm.uiController.SetShield(shield);
    }

    public override void GetDammage(int amount)
    {
        if (shield > 0)
        {
            int shieldPercentage = (amount * 75) / 100;

            if(shield >= shieldPercentage)
            {
                shield -= shieldPercentage;
                health -= amount - shieldPercentage;
            }
            else
            {
                health -= amount - shield;
                shield = 0;
            }

        }
        else if(health > 0)
            health -= amount;

        gm.uiController.SetHealth(health);
        gm.uiController.SetShield(shield);


        if (health <= 0)
            Dead();

    }

    public bool HaveMaxShield()
    {
        return shield >= maxShield;
    }

}
