using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private int pelletCount;

    [SerializeField]
    private float spread;

  protected override void Shoot()
	{
		Vector2 rnd;
		for(int i = 0; i < pelletCount; i++) {
			var bull = Instantiate(bullet, firePoint.position, firePoint.rotation);         
			rnd = Random.insideUnitCircle * spread;
			bull.transform.Rotate(rnd.x, rnd.y, 0);
			bull.AddForce(bull.transform.forward * bulletSpeed, ForceMode.Impulse);
		}
		//Debug.Break();
	}
}
