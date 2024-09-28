using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    private bool canMove = false;

    private void Start()
    {
        //score = FindObjectOfType<KitsuneAttacks>();
        //score.OnIncreaseSpped.AddListener(IncreaseSpeed);
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        MoveProjectile();
    }

    public void MoveProjectile()
    {
        this.transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
    }

    public void IncreaseSpeed(int newSpeed)
    {
        moveSpeed = newSpeed;
        Debug.Log("Speed" + moveSpeed);
    }
    public int GetCurrentSpeed()
    {
        return moveSpeed;
    }
    public void Move()
    {
        canMove = true;
    }
    public void Stop()
    {
        canMove = false;
    }
}
