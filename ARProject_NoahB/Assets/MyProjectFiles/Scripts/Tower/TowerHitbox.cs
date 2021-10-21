using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHitbox : MonoBehaviour
{
    public Tower myTower;

    public void GetHit(float damage)
    {
        myTower.TakeDamage(damage);
    }
}
