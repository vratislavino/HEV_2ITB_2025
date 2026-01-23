using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private int maxAmmo;
    private int currentAmmo;

    [SerializeField]
    private float reloadTime;
    private float remainingReloadTime;
    public bool IsReloading => remainingReloadTime > 0;

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
        if (IsReloading) return;
        if (currentAmmo <= 0) return;

        Shoot();
    }

    public void Reload()
    {
        if (IsReloading) return;

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
        if(IsReloading) {
            remainingReloadTime -= Time.deltaTime;
            if(remainingReloadTime <= 0)
            {
                currentAmmo = maxAmmo;
                remainingReloadTime = 0;
            }
        }
    }
}
