using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum PlayerClickType
{
    PlaceTurret = 0,
    KillGoblin = 1
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    protected float gametime = 0f;

    public float GameTime { get { return gametime; } }

    public Tower theTower;

    public static GameManager Main;

    public List<Goblin> goblins = new List<Goblin>();

    public List<GobSpawner> spawners = new List<GobSpawner>();

    public static float goblinRespawnMod = 0f;

    public int points = 0;

    public int maxTurrets = 5;

    public int currentTurrets = 0;

    public PlayerClickType touchType = PlayerClickType.KillGoblin;

    public GameObject turretPrefab;

    public GameObject gameOverUI;

    public bool gameIsOver = false;

    public delegate void GameOverDelegate();

    public static GameOverDelegate gameEnd;

    private void Awake()
    {
        if (Main) { Destroy(gameObject); }
        else { Main = this; }
        //Time.timeScale = 1f;
        
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            gametime += Time.deltaTime;

            goblinRespawnMod = gametime / 60;
        }
        
    }

    public void TouchRaycast(Ray touch)
    {
        if (!gameIsOver)
        {
            RaycastHit hit;

            switch (touchType)
            {
                case PlayerClickType.KillGoblin:
                    if (Physics.Raycast(touch, out hit))
                    {
                        if (hit.collider.gameObject.CompareTag("Goblin"))
                        {
                            GobbAttackRange gob = hit.collider.gameObject.GetComponent<GobbAttackRange>();
                            if (gob) { gob.Me.GetHit(); }
                        }
                    }
                    break;
                case PlayerClickType.PlaceTurret:
                    if (Physics.Raycast(touch, out hit))
                    {
                        if (hit.collider.gameObject.CompareTag("ValidGround") && currentTurrets < maxTurrets)
                        {
                            Instantiate(turretPrefab, hit.point, Quaternion.identity);
                            currentTurrets++;
                            points -= 15;
                        }
                        SetTouchType(PlayerClickType.KillGoblin);
                    }
                    break;
            }
        }
        
    }

    //public void ARTouchRaycast()

    public void GetPoint()
    {
        points++;
    }

    public void SetTouchType(PlayerClickType type)
    {
        touchType = type;
    }

    public void GameOver()
    {
        //Time.timeScale = 0f;
        gameEnd?.Invoke();
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
