using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected int maxAmmo = 200;
    [SerializeField] protected int maxLoader = 8;
    [SerializeField] protected int damage = 15;
    [SerializeField] protected float cadence = 1;
    [HideInInspector] public int ammo;
    [HideInInspector] public int gunAmmo;
    [HideInInspector] protected bool reloading;
    [HideInInspector] protected Animator anim;
    [SerializeField] protected GameObject particles = null;
    [HideInInspector] protected Transform particlesSpawn;
    [HideInInspector] protected UIController uiController;

    [HideInInspector] protected float lastTime;

    protected void Start()
    {
        anim = GetComponent<Animator>();
        particlesSpawn = transform.GetChild(0);
        uiController = GameManager.instance.uiController;

        gunAmmo = maxLoader;
        ammo = maxAmmo - maxLoader;
    }

    public abstract void Shoot();

    public abstract void Reload();

    public void AddAmmo(int ammount)
    {
        if (ammo == maxAmmo)
            return;

        ammo += ammount;
        if (ammo > maxAmmo)
            ammo = maxAmmo;

        UpdateText();
    }

    protected void InstantiateParticles()
    {
        GameObject part = Instantiate(particles, particlesSpawn.position, Quaternion.identity);
        part.transform.SetParent(transform);
        Destroy(part, .5f);
    }

    protected void UpdateText()
    {
        uiController.SetAmoText(gunAmmo, ammo);
    }

    public bool HaveMaxAmmo()
    {
        return ammo >= maxAmmo;
    }

}
