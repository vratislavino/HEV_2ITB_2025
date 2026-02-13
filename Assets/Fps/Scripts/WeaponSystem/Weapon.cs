using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    public event Action<bool> ReloadStateChanged;
    public event Action AmmoChanged;

    [SerializeField]
    private int maxAmmo;
    public int MaxAmmo => maxAmmo;
    
    private int currentAmmo;
    public int CurrentAmmo => currentAmmo;

    [SerializeField]
    private float reloadTime;
    private float remainingReloadTime;
    public bool IsReloading => remainingReloadTime > 0;
    public float ReloadProgress => remainingReloadTime / reloadTime;

    [SerializeField]
    protected float bulletSpeed = 5f;

    [SerializeField]
    protected Rigidbody bullet;
    [SerializeField]
    protected Transform firePoint;

    [SerializeField]
    protected float fireRate = 0.2f;
    private float fireCooldown = 0;

    void Start()
    {
        ChangeAmmo(maxAmmo);
    }

    private void ChangeAmmo(int newAmmo)
    {
        currentAmmo = newAmmo;
        AmmoChanged?.Invoke();
    }

    public virtual bool CanAttack(InputAction fireAction)
    {
        return fireAction.WasPressedThisFrame();
    }

    public void Attack()
    {
        if (IsReloading) return;
        if (currentAmmo <= 0) return;
        if (fireCooldown > 0) return;


        ChangeAmmo(currentAmmo - 1);
        fireCooldown = fireRate;

        Shoot();
    }

    public void Reload()
    {
        if (IsReloading) return;

        remainingReloadTime = reloadTime;
        ReloadStateChanged?.Invoke(true);
    }

    protected virtual void Shoot()
    {
        var bull = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bull.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        if(IsReloading) {
            remainingReloadTime -= Time.deltaTime;
            if(remainingReloadTime <= 0)
            {
                ChangeAmmo(maxAmmo);
                remainingReloadTime = 0;
                ReloadStateChanged?.Invoke(false);
            }
        }

        fireCooldown -= Time.deltaTime;
    }
}
