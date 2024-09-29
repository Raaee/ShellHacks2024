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
    public int CurrentDamage { get; set; } // current damage the projectile does

    private const string Kitsune_Proj1_TAG = "Kitsune Projectile";
    private const string Kitsune_Proj2_TAG = "Kitsune Wall";
    private const string PLAYER_TAG = "Player"; // Tag used to identify the player.
    private const string Player_Proj_TAG = "Player Projectile"; 
    private bool canMove = true;

    private Rigidbody2D rb2D;
    [SerializeField] private bool isPlayerShooting;

    [HideInInspector] public UnityEvent OnProjectileDisabled;
    [HideInInspector] public UnityEvent<float> OnRemoveHeath;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }   
    private void FixedUpdate()
    {
        if (!canMove) return;
        MoveProjectile();
    }

    public void MoveProjectile() {
        if (isPlayerShooting) {
            this.transform.position += Vector3.right * projectileSpeed * Time.fixedDeltaTime;
        }
        else {
            this.transform.position += Vector3.left * projectileSpeed * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Kitsune_Proj1_TAG))
        {

            ProjectileHealthPoints projectileHealth = collider.gameObject.GetComponent<ProjectileHealthPoints>();
            if (!projectileHealth)
            {
                return;
            }
            projectileHealth.RemoveHealth(CurrentDamage);

            if (projectileHealth.IsDead())
            {
                projectileHealth.Die();
            }


        }
        else if (collider.gameObject.CompareTag(Kitsune_Proj2_TAG))
        {
            Debug.Log("WallHit");
            ProjectileHealthPoints projectileHealth = collider.gameObject.GetComponent<ProjectileHealthPoints>();
            if (!projectileHealth)
            {
                return;
            }
            projectileHealth.RemoveHealth(CurrentDamage);

            if (projectileHealth.IsDead())
            {
                projectileHealth.Die();
            }
        }
        else if (collider.gameObject.CompareTag(PLAYER_TAG)) // ignore player proj when hitting player
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
            Debug.Log(CurrentDamage);
            if (gameObject.CompareTag(Kitsune_Proj2_TAG))
            {
                potentialPlayerHealth.RemoveHealth(5);

                OnRemoveHeath.Invoke(5);
            }
            else
            {
                potentialPlayerHealth.RemoveHealth(1);
                OnRemoveHeath.Invoke(1);
            }


            if (potentialPlayerHealth.IsDead())
            {
                potentialPlayerHealth.Die();
            }
            DisableProjectile();
        }
       
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
    public float GetCurrentSpeed() {
        return projectileSpeed;
    }

    public void IncreaseSpeed(int newSpeed) {
        projectileSpeed = newSpeed;
        Debug.Log("Speed" + projectileSpeed);
    }
}
