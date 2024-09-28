using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    private float lifeTime = 2f;
    public int CurrentDamage { get; set; }
    private Rigidbody2D rb;
    private float timer = 0f;
    [HideInInspector] public UnityEvent OnProjectileDisabled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveProjectile();

        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            OnProjectileDisabled.Invoke();
            DisableProjectile();
        }
    }

    public void MoveProjectile() {
       // this.transform.position += Vector3.left * _speed * Time.fixedDeltaTime;
       rb.velocity = transform.right * _speed;
    }

    private void DisableProjectile()
    {
        OnProjectileDisabled?.Invoke();
        Destroy(this.gameObject);
    }

    public void SetLifeTime(float life)
    {
        lifeTime = life;
    }
}
