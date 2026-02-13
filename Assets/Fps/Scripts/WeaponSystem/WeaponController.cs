using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    List<Weapon> weapons;
    Weapon currentWeapon;

    InputAction attackAction;
    InputAction reloadAction;
    InputAction prevAction;
    InputAction nextAction;

    [SerializeField]
    private FpsUiManager uiManager;

    void Awake()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        reloadAction = InputSystem.actions.FindAction("Reload");
        prevAction = InputSystem.actions.FindAction("Previous");
        nextAction = InputSystem.actions.FindAction("Next");


        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        weapons.ForEach(w => w.gameObject.SetActive(false));
        SelectWeapon(0);
    }

    void Start()
    {
        
    }

    private void SelectWeapon(int index)
    {
        if(currentWeapon)
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon.AmmoChanged -= OnAmmoChanged;
            currentWeapon.ReloadStateChanged -= OnReloadStateChanged;
        }

        currentWeapon = weapons[index];
        uiManager.ChangeWeaponName(currentWeapon);
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.AmmoChanged += OnAmmoChanged;
        currentWeapon.ReloadStateChanged += OnReloadStateChanged;
    }

    private void OnAmmoChanged()
    {
        uiManager.ChangeAmmoText(currentWeapon.CurrentAmmo, currentWeapon.MaxAmmo);
    }

    private void OnReloadStateChanged(bool isReloading)
    {
        if(isReloading)
            uiManager.StartedReloading(currentWeapon);
        else
            uiManager.StoppedReloading();
    }

    void Update()
    {
        if(currentWeapon.CanAttack(attackAction))
        {
            currentWeapon.Attack();
        }

        if(reloadAction.WasPressedThisFrame())
        {
            currentWeapon.Reload();
        }

        if(!currentWeapon.IsReloading)
        {
            if(prevAction.WasPressedThisFrame())
                PrevWeapon();

            if(nextAction.WasPressedThisFrame())
                NextWeapon();
        }
    }

    void PrevWeapon()
    {
        int index = weapons.IndexOf(currentWeapon);
        index = (index - 1 + weapons.Count) % weapons.Count;
        SelectWeapon(index);
    }

    void NextWeapon()
    {
        int index = weapons.IndexOf(currentWeapon);
        index = (index + 1) % weapons.Count;
        SelectWeapon(index);
    }
}
