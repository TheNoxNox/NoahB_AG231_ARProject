using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobbAttackRange : MonoBehaviour
{
    public Goblin Me;

    private void OnTriggerEnter(Collider other)
    {
        Tower tower = other.gameObject.GetComponentInChildren<Tower>();

        if (tower)
        {
            Me.ReachedTower(tower);
        }
    }
}
