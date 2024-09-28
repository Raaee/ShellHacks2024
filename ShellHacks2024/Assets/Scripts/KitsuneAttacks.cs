using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitsuneAttacks : MonoBehaviour
{
    [SerializeField] public Score_Points score;
    [SerializeField] private Transform maxLimitSpawn;
    [SerializeField] private Transform minLimitSpawn;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile2;
    [SerializeField] private Transform projectilesParentObject;

    [SerializeField] private int speedIncreaseAmount = 2;
    public int currentProjSpeed;

    [SerializeField] private bool isPlayerDead;

    [SerializeField] public bool is25Seconds = false;

    [HideInInspector] public UnityEvent OnIncreaseSpped;

    void Start()
    {
        score.OnSpeedUpInterval.AddListener(SpeedUpProjectiles);
        currentProjSpeed = projectile.GetComponent<Projectile>().GetCurrentSpeed();
        SpawnProjectile();
    }
    private void SpawnProjectile() {
        StartCoroutine(DelayProjectileSpawn());
    }

    public IEnumerator DelayProjectileSpawn() {
        while (!isPlayerDead) {
            GameObject projectile1GO = Instantiate(projectile, projectilesParentObject);
            projectile1GO.transform.localPosition = new Vector3(this.transform.position.x, Random.Range(maxLimitSpawn.position.y, minLimitSpawn.position.y));
            Projectile proj1 = projectile1GO.GetComponent<Projectile>();
            proj1.Stop();
            GameObject projectile2GO = null;
            proj1.IncreaseSpeed(currentProjSpeed);
            if (projectile2GO)
                projectile2GO.GetComponent<Projectile>().IncreaseSpeed(currentProjSpeed);
            proj1.Move();
            /*if (is25Seconds)
            {
                is25Seconds = false;
                InstanceP2 =  Instantiate(projectile2, parentTansform);
                InstanceP2.transform.localPosition = new Vector3(this.transform.position.x, Random.Range(maxLimitSpawn.position.y, minLimitSpawn.position.y));
            }*/

            yield return new WaitForSeconds(2);
        }
        
    }
    private void SpeedUpProjectiles()
    {
        Debug.Log("interval");
        currentProjSpeed += speedIncreaseAmount;
    }
    /*private void SpawnProjectile() {
        is25Seconds = true;
    }*/

    
}
