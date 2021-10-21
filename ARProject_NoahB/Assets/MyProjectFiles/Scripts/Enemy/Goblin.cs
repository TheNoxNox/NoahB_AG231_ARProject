using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected NavMeshAgent agent;

    public float speed = 6.0f;
    public float runSpeed = 1.7f;

    public GobbAttackRange myAttackRange;

    private Tower reachedTower;

    private void Awake()
    {
        agent.SetDestination(GameManager.Main.theTower.location);
        animator.SetInteger("moving", 2);//run
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReachedTower(Tower theTower)
    {
        reachedTower = theTower;
        agent.SetDestination(transform.position); // stop moving
    }
}
