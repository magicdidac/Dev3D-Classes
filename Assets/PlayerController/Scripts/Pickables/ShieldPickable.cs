using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickable : Pickable
{
    [SerializeField] private int shieldGive = 10;

    public override void GetPickable(FPSController player)
    {
        if (!player.dmgShield.HaveMaxShield())
        {
            player.dmgShield.AddShield(shieldGive);
            Destroy(gameObject);
        }
    }
}
