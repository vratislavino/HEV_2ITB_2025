using UnityEngine;
using UnityEngine.InputSystem;

public class Smg : Weapon
{
    public override bool CanAttack(InputAction fireAction)
    {
        return fireAction.IsPressed();
    }
}
