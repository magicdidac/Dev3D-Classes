using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickable : Pickable
{
    public override void GetPickable(FPSController player)
    {
        player.haveGun = true;
        player.gun.gameObject.SetActive(true);
        player.uiController.SetActiveGunInfo();
        Destroy(gameObject);
    }
}
