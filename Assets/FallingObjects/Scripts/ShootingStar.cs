using UnityEngine;

public class ShootingStar : FallingObject
{
    public override void OnHit(Player p)
    {
        base.OnHit(p);
        p.AddScore(5);
    }
}
