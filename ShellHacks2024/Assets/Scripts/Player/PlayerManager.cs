using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public static PlayerManager Instance { get; set; }
    [HideInInspector] public PlayerHealthPoints hp { get; set; }
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float reviveTime = 1f;
    private GameObject deathPanelClone;

    [HideInInspector] public UnityEvent OnRevive;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Components();
        hp.OnDead.AddListener(Death);
        Respawn();
    }

    private void Components()
    {
        hp = player.GetComponent<PlayerHealthPoints>();
    }

    public void Death()
    {
        StartCoroutine(WaitBeforeDisable());
    }

    [ProButton]
    private void Respawn()
    {
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
        hp.ResetHealth();

    }

    public IEnumerator WaitBeforeDisable()
    {
        yield return new WaitForSeconds(reviveTime);
        DisablePlayer();
    }

    private void DisablePlayer()
    {
        Destroy(player.gameObject);
        
    } 
    public void Init()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void SetPlayer(GameObject prefab)
    {
        player = prefab;
        
    }

    private void SetSpawnPoint(Transform loc)
    {
        spawnPoint = loc;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    private void DestoryDeathPanel()
    {
        Destroy(deathPanelClone);
    }
}
