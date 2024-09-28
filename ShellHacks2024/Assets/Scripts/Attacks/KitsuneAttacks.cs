using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitsuneAttacks : MonoBehaviour
{
    [SerializeField] public Score_Points score;
    [SerializeField] private Transform maxLimitSpawn;
    [SerializeField] private Transform minLimitSpawn;
    [SerializeField] private Transform startingXPos;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile2;
    [SerializeField] private Transform projectilesParentObject;

    [SerializeField] private int speedIncreaseAmount = 2;
    public int currentProjSpeed;

    [SerializeField] private bool isPlayerDead;

    [SerializeField] public bool is25Seconds = false;

    [HideInInspector] public UnityEvent OnIncreaseSpped;

    [SerializeField] private float waitTime = 1;

    void Start()
    {
        score.OnSpeedUpInterval.AddListener(SpeedUpProjectiles);
        score.OnSpawnProjectile2.AddListener(Spawn2Projectile);
        currentProjSpeed = (int)projectile.GetComponent<NewProjectile>().GetCurrentSpeed();
        SpawnProjectile();

    }
    private void SpawnProjectile() {
        StartCoroutine(DelayProjectileSpawn());
    }

    public IEnumerator DelayProjectileSpawn() {
        while (!isPlayerDead) {
            GameObject projectile1GO = Instantiate(projectile, projectilesParentObject);

            float randomYpos = Random.Range(minLimitSpawn.localPosition.y, maxLimitSpawn.localPosition.y);
            projectile1GO.transform.position = new Vector3(startingXPos.transform.localPosition.x, randomYpos, 0f);
            NewProjectile proj1 = projectile1GO.GetComponent<NewProjectile>();
            //proj1.Stop();
            
            proj1.IncreaseSpeed(currentProjSpeed);
            if (is25Seconds)
            {
                GameObject projectile2GO = Instantiate(projectile2, projectilesParentObject);
                projectile2GO.transform.position = startingXPos.transform.position;
                NewProjectile proj2 = projectile2GO.GetComponent<NewProjectile>();
                is25Seconds = false;
            }
            

            yield return new WaitForSeconds(waitTime);
        }
        
    }
    private void SpeedUpProjectiles()
    {
        Debug.Log("interval");
        currentProjSpeed += speedIncreaseAmount;
    }
    private void Spawn2Projectile() {
        is25Seconds = true;
    }

    
}
