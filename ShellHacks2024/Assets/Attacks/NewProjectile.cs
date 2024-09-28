using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// The Projectile class handles the behavior of projectiles in the game.
public class NewProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10f; // The speed of the projectile.
    [SerializeField]private float lifeTime = 10f; // The maximum lifetime of the projectile.
    public int CurrentDamage { get; set; } // current damage the projectile does

    private const string Kitsune_Proj_TAG = "Kitsune Projectile"; // Tag used to identify enemies.
    private const string PLAYER_TAG = "Player"; // Tag used to identify the player.
    private const string Player_Proj_TAG = "Player Projectile"; // Tag used to identify the crystal.
    private Vector2 moveDirection;

    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D; // The Rigidbody2D component of the projectile.

    private bool isPlayerShooting = true;

    [HideInInspector] public UnityEvent OnProjectileDisabled;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
   

    private void FixedUpdate()
    {
        MoveProjectile();

        timer += Time.deltaTime;

        // If the projectile has existed for longer than its maximum lifetime, disable it
        if (timer >= lifeTime)
        {
            DisableProjectile();
            timer = 0;
        }
    }
    public void SetMoveDirection(Vector2 movDir, bool isPlayerShooting)
    {
        this.isPlayerShooting = isPlayerShooting;
        moveDirection = movDir;
    }

    
    public void MoveProjectile()
    {
        rb2D.velocity = moveDirection * projectileSpeed;

    }

    // Sets the direction in which the projectile should move.
   

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Kitsune_Proj_TAG))
        {
            
            ProjectileHealthPoints projectileHealth = collider.gameObject.GetComponent<ProjectileHealthPoints>();

            if (!projectileHealth)
            {
                return;
            }
            projectileHealth.RemoveHealth(CurrentDamage);

            if(projectileHealth.IsDead())
            {
                projectileHealth.Die();
            }

            // Disable the projectile after it has hit an enemy
            //DisableProjectile();
            
        }
        // Check if the projectile has collided with the player
        else if (collider.gameObject.CompareTag(PLAYER_TAG))
        {
            if (gameObject.CompareTag(Player_Proj_TAG))
            {
                return;
            }

            PlayerHealthPoints potentialPlayerHealth = collider.gameObject.GetComponent<PlayerHealthPoints>();

            if (!potentialPlayerHealth)
            {
                return;
            }

            potentialPlayerHealth.RemoveHealth(CurrentDamage);

            if (potentialPlayerHealth.IsDead())
            {
                potentialPlayerHealth.Die();
            }

        }
        // Check if the projectile has collided with the crystal
        else if (collider.gameObject.CompareTag(Player_Proj_TAG))
        {

            ProjectileHealthPoints playerProjectileHealth = collider.gameObject.GetComponent<ProjectileHealthPoints>();

            if (!playerProjectileHealth)
            {
                return;
            }
            playerProjectileHealth.RemoveHealth(CurrentDamage);
            playerProjectileHealth.Die();


                 
        }
    }

    private void DisableProjectile()
    {
        Debug.Log("Projectile disabled");
        OnProjectileDisabled?.Invoke();
        Destroy(this.gameObject);
    }
    public void SetLifeTime(float life)
    {
        lifeTime = life;
    }
}
