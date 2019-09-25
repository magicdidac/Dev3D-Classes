using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BitGun : MonoBehaviour
{

    [SerializeField] private int maxAmmo = 200;
    [SerializeField] private int maxLoader = 8;
    [SerializeField] private int damage = 15;
    [SerializeField] private float cadence = 1;
    [HideInInspector] private int ammo;
    [HideInInspector] private int gunAmmo;
    [HideInInspector] private bool reloading;
    [HideInInspector] private Transform cam;
    [HideInInspector] private Animator anim;

    [HideInInspector] private PlayerControls controls;

    [HideInInspector] private UIController uiController;

    [HideInInspector] private float lastTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;

        controls = transform.parent.parent.GetComponent<FPSController>().controls;

        uiController = transform.parent.parent.GetComponent<FPSController>().uiController;

        controls.Player.Fire.performed += _ => Shoot();
        controls.Player.Reload.performed += _ => Reload();

        gunAmmo = maxLoader;
        ammo = maxAmmo - maxLoader;

    }

    private void Shoot()
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

        lastTime = Time.time;
        gunAmmo--;

        UpdateText();
    }

    private void Reload()
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
