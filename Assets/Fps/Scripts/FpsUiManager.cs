using UnityEngine;
using UnityEngine.UI;

public class FpsUiManager : MonoBehaviour
{
    public Image reloadCrosshair;
    public GameObject normalCrosshair;

    [Header("Weapon Info")]
    public TMPro.TMP_Text weaponName;
    public TMPro.TMP_Text ammo;

    Weapon currentlyReloadingWeapon = null;

    public void ChangeAmmoText(int current, int max)
    {
        ammo.text = $"{current}/{max}";
    }

    public void ChangeWeaponName(Weapon w)
    {
        weaponName.text = w.name;
    }

    public void StartedReloading(Weapon w)
    {
        currentlyReloadingWeapon = w;
        reloadCrosshair.gameObject.SetActive(true);
        normalCrosshair.SetActive(false);
    }

    public void StoppedReloading()
    {
        currentlyReloadingWeapon = null;

        reloadCrosshair.gameObject.SetActive(false);
        normalCrosshair.SetActive(true);
    }

    void Update()
    {
        if (currentlyReloadingWeapon)
        {
            reloadCrosshair.fillAmount = currentlyReloadingWeapon.ReloadProgress;
        }
    }
}
