using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobSpawner : MonoBehaviour
{
    public GameObject goblinPrefab;

    public float spawnCD_Max = 10f;
    public float spawnCD_Min = 6f;
    public float spawnCD_Min_Abs = 2f;
    //public float spawnCD_Mod = 0f;

    public float spawnCooldown = 0f;

    private void Awake()
    {
        spawnCooldown = Random.Range(spawnCD_Min,spawnCD_Max) - GameManager.goblinRespawnMod;
    }

    private void Update()
    {
        if (!GameManager.Main.gameIsOver)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0)
            {
                Instantiate(goblinPrefab, transform.position, transform.rotation);
                spawnCooldown = Random.Range(spawnCD_Min, spawnCD_Max) - GameManager.goblinRespawnMod;
                if (spawnCooldown < spawnCD_Min_Abs) { spawnCooldown = spawnCD_Min_Abs; }
            }
        }
        
    }
}
