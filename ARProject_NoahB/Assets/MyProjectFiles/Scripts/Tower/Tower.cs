using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float durabilityMax = 100f;
    protected float durabilityCurrent = 100f;
    public float DurabilityPercent { get { return durabilityCurrent / durabilityMax; } }

    public Vector3 location { get; private set; }

    private void Awake()
    {
        durabilityCurrent = durabilityMax;
        location = gameObject.transform.position;
    }

    public void TakeDamage(float damage)
    {
        durabilityCurrent -= damage;

        if(durabilityCurrent <= 0)
        {

        }
    }


}
