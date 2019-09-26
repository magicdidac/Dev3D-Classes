using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerWithShield : Damager
{

    [SerializeField] private int maxShield = 100;
    [HideInInspector] private int shield;

    private new void Start()
    {
        base.Start();
        shield = 0;
        uiController.SetShield(shield);
    }

    public void GetShield(int amount)
    {
        shield += amount;
        if (shield > maxShield)
            shield = maxShield;

        uiController.SetShield(shield);
    }

    public new void GetDammage(int amount)
    {
        if(shield > 0)
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
        else
            health -= amount;

        uiController.SetHealth(health);
        uiController.SetShield(shield);

        if (health <= 0)
            Dead();

    }


}
