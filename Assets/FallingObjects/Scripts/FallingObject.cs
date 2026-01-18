using UnityEngine;

public abstract class FallingObject : MonoBehaviour
{
    public AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public virtual void OnHit(Player p)
    {
        source.Play();
    }
}
