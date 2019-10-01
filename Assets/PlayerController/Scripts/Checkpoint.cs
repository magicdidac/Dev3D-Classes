using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Checkpoint : MonoBehaviour
{
    [HideInInspector] private Renderer rend;
    [HideInInspector] private GameManager gm;

    [SerializeField] private Material offMaterial = null;
    [SerializeField] private Material onMaterial = null;

    [HideInInspector] public int shieldAmount = 0;
    [HideInInspector] public int healthAmount = 0;
    [HideInInspector] public int ammoAmount = 0;
    [HideInInspector] public int loaderAmmoAmount = 0;
    [HideInInspector] public Quaternion playerRotation;

    private void Start()
    {
        this.tag = "Checkpoint";

        gm = GameManager.instance;

        rend = GetComponent<Renderer>();

        if (!Application.isEditor)
            rend.enabled = false;
    }

    public void EnableCheckpoint(FPSController player)
    {
        if (gm.checkpoint != null)
            gm.checkpoint.DisableCheckpoint();

        gm.checkpoint = this;

        shieldAmount = player.dmgShield.shield;
        healthAmount = player.dmgShield.health;
        ammoAmount = player.gun.ammo;
        loaderAmmoAmount = player.gun.gunAmmo;
        playerRotation = player.transform.rotation;

        if(Application.isEditor)
            rend.material = onMaterial;
    }

    public void DisableCheckpoint()
    {
        if (Application.isEditor)
            rend.material = offMaterial;
    }

    public void SetPlayerStats()
    {

        gm.player.dmgShield.shield = shieldAmount;
        gm.player.dmgShield.health = healthAmount;
        gm.player.gun.ammo = ammoAmount;
        gm.player.gun.gunAmmo = loaderAmmoAmount;

        gm.player.UpdateUIInformation();

        Invoke("ChangePosPlayer", 1f);
    }

    private void ChangePosPlayer()
    {
        gm.player.characterController.enabled = false;
        gm.player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gm.player.transform.rotation = playerRotation;
        gm.player.characterController.enabled = true;

        gm.uiController.ChangeFade();
    }

}
