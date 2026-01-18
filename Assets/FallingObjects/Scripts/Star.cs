using UnityEngine;

public class Star : FallingObject
{
    public override void OnHit(Player p)
    {
        p.AddScore(1);
        base.OnHit(p);
    }
}
