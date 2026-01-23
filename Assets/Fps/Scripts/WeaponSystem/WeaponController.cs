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

    void Awake()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        reloadAction = InputSystem.actions.FindAction("Reload");

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
            // odregistrování z událostí
        }

        currentWeapon = weapons[index];
        currentWeapon.gameObject.SetActive(true);
    }

    void Update()
    {
        if(attackAction.WasPressedThisFrame())
        {
            currentWeapon.Attack();
        }

        if(reloadAction.WasPressedThisFrame())
        {
            currentWeapon.Reload();
        }
    }
}
