using UnityEngine;

public class BlackHole : FallingObject
{
    public override void OnHit(Player p)
    {
        base.OnHit(p);
        Destroy(p.gameObject);
    }
}
