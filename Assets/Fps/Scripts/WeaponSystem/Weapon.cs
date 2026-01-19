using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private int maxAmmo;
    private int currentAmmo;
    private bool isReloading;

    [SerializeField]
    private float reloadTime;
    private float remainingReloadTime;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private Transform firePoint;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    public void Attack()
    {
        if (isReloading) return;
        if (currentAmmo <= 0) return;

        Shoot();
    }

    public void Reload()
    {
        if (isReloading) return;

        isReloading = true;
        remainingReloadTime = reloadTime;
    }

    private void Shoot()
    {
        currentAmmo--;
        var bull = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bull.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        Shoot();
    }
}
