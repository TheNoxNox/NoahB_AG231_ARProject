using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    protected float gametime = 0f;

    public Tower theTower;

    public static GameManager Main;

    public List<Goblin> goblins = new List<Goblin>();

    public List<GobSpawner> spawners = new List<GobSpawner>();

    public static float goblinRespawnMod = 0f;

    private void Awake()
    {
        if (Main) { Destroy(gameObject); }
        else { Main = this; }
    }

    private void Update()
    {
        gametime += Time.deltaTime;

        goblinRespawnMod = gametime / 50;
    }

    public void TouchRaycast(Ray touch)
    {
        RaycastHit hit;

        if(Physics.Raycast(touch,out hit))
        {
            if (hit.collider.gameObject.CompareTag("Goblin"))
            {
                GobbAttackRange gob = hit.collider.gameObject.GetComponent<GobbAttackRange>();
                if (gob) { gob.Me.GetHit(); }
            }
        }
    }
}
