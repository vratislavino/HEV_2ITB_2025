using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    public event Action<int> OnScoreChanged;

    InputAction moveAction;
    public float speed;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        transform.Translate(move.x * speed * Time.deltaTime, 0, 0);
    }

    public void AddScore(int amount)
    {
        score += amount;

        // vyvolání události
        OnScoreChanged?.Invoke(score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var f = collision.collider.GetComponent<FallingObject>();
        if(f != null)
        {
            f.OnHit(this);
            Destroy(collision.collider.gameObject);
        }
        else
        {
            Debug.Log("Nìco jiného než FallingObject" + collision.collider.name);
        }
    }
}
