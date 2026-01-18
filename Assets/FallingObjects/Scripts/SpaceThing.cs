using System.Collections;
using UnityEngine;

public class SpaceThing : FallingObject
{
    Player player;
    public override void OnHit(Player p)
    {
        player = p;
        p.speed *= 2f; // <--- important ☺♥
        StartCoroutine(SlowDown());

        base.OnHit(p);
    }

    private IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(10f);
        player.speed /= 2f;
    }
}
