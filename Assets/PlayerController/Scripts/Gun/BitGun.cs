using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : Gun
{
    [HideInInspector] private Transform cam;

    [HideInInspector] private PlayerControls controls;

    [HideInInspector] private UIController uiController;


    private new void Start()
    {
        base.Start();

        cam = Camera.main.transform;

        controls = transform.parent.parent.GetComponent<FPSController>().controls;

        uiController = transform.parent.parent.GetComponent<FPSController>().uiController;

        controls.Player.Fire.performed += _ => Shoot();
        controls.Player.Reload.performed += _ => Reload();
    }

    public override void Shoot()
    {
        if (gunAmmo <= 0)
        {
            Reload();
            return;
        }

        if (reloading)
            return;

        if (Time.time < lastTime + cadence)
            return;

        anim.SetTrigger("shoot");

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit))
        {
            try
            {
                hit.collider.GetComponent<Damager>().GetDammage(damage);
            }
            catch { }
        }

        InstantiateParticles();

        lastTime = Time.time;
        gunAmmo--;

        UpdateText();
    }

    public override void Reload()
    {
        if (gunAmmo == maxLoader)
            return;

        if (reloading)
            return;

        reloading = true;

        anim.SetTrigger("reload");

    }

    public void AddAmmo(int ammount)
    {
        if (ammo == maxAmmo)
            return;

        ammo += ammount;
        if (ammo > maxAmmo)
            ammo = maxAmmo;

        UpdateText();
    }

    private void NowReload()
    {
        ammo -= maxLoader - gunAmmo;
        gunAmmo = maxLoader;
        reloading = false;

        UpdateText();
    }

    private void UpdateText()
    {
        uiController.SetAmoText(gunAmmo + " / " + ammo);
    }

}
