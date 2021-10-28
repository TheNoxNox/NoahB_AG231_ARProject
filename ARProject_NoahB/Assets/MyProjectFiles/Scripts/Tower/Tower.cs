using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float durabilityMax = 100f;
    [SerializeField]
    protected float durabilityCurrent = 100f;
    public float DurabilityPercent { get { return durabilityCurrent / durabilityMax; } }

    [SerializeField]
    public Vector3 location { get { return gameObject.transform.position; } }

    private void Awake()
    {
        durabilityCurrent = durabilityMax;
    }

    public void TakeDamage(float damage)
    {
        durabilityCurrent -= damage;

        if(durabilityCurrent <= 0 && !GameManager.Main.gameIsOver)
        {
            GameManager.Main.GameOver();
        }
    }


}
