using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed = 5;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    public void MoveProjectile() {
        this.transform.position += Vector3.left * _speed * Time.fixedDeltaTime;
    }
}
