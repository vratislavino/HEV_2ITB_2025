using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // spustit coroutine na detonationTime
    // radius
    // explosionForce

    void Start()
    {
        StartCoroutine(BoomBoomRoutine())
    }

    private IEnumerator BoomBoomRoutine()
    {
        yield return new WaitForSeconds(4f);
        // najít objekty v dosahu raidusu
        // aplikovat sílu pomocí rigidbody
        // Physics.OverlapSphere()
        // col.GetComponent<Rigidbody>();
        // if(má rigidbody?)
        // rb.AddExplosionForce()
        Destroy(gameObject);
    }
}
