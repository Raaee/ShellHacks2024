using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitsuneAttacks : MonoBehaviour
{
    [SerializeField] private Transform maxLimitSpawn;
    [SerializeField] private Transform minLimitSpawn;

    [SerializeField] private GameObject projectile;

    [SerializeField] private int amountUsed = 10;


    // Start is called before the first frame update
    void Start()
    {
        SpawnProjectile();
    }
    private void SpawnProjectile() {
        StartCoroutine(DeleayProjectileSpawm());
    }

    public IEnumerator DeleayProjectileSpawm() {
        for (int i = 0; i < amountUsed; i++) {
            Instantiate(projectile, new Vector3(this.transform.position.x, Random.Range(maxLimitSpawn.position.y, minLimitSpawn.position.y)), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
