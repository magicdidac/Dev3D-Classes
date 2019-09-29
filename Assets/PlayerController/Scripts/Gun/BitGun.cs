using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : Gun
{
    [HideInInspector] private Transform cam;

    [HideInInspector] private PlayerControls controls;


    private new void Start()
    {
        base.Start();

        cam = Camera.main.transform;

        controls = transform.parent.parent.GetComponent<FPSController>().controls;

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

    private void NowReload()
    {
        ammo -= maxLoader - gunAmmo;
        gunAmmo = maxLoader;
        reloading = false;

        UpdateText();
    }

    

}
