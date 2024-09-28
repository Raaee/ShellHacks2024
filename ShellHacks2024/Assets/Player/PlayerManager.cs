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
    [SerializeField] private GameObject reviveParticles;
    [SerializeField] string reviveParticleGOName;
    [SerializeField] private float reviveTime = 1f;
    private GameObject deathPanelClone;

    public UnityEvent OnRevive;

    private Animator animator;
    private const string DEATH = "Death";
    private const string RESPAWN = "Respawn";

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Components();
        hp.OnDead.AddListener(Death);
        reviveParticles.SetActive(false);
        Respawn();
    }

    private void Components()
    {
        hp = player.GetComponent<PlayerHealthPoints>();
        animator = player.GetComponent<Animator>();
        reviveParticles = GameObject.Find(reviveParticleGOName);
    }

    public void Death()
    {
        animator.Play(DEATH);
        StartCoroutine(WaitBeforeDisable());
    }

    [ProButton]
    private void Respawn()
    {
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
        StartCoroutine(Revive());
        animator.Play(RESPAWN);
        hp.ResetHealth();

    }

    public IEnumerator WaitBeforeDisable()
    {
        yield return new WaitForSeconds(reviveTime);
        DisablePlayer();
    }

    private void DisablePlayer()
    {
        player.gameObject.SetActive(false);
        
    }

    public IEnumerator Revive()
    {
        reviveParticles.SetActive(true);
        yield return new WaitForSeconds(reviveTime);
        reviveParticles.SetActive(false);
        
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
