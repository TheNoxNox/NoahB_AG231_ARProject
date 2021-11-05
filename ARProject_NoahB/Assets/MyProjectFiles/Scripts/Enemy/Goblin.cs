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
    private bool hasReachedTower = false;

    public float damage = 3f;
    public int attackCycle = 3;

    public float attackCdMax = 1.5f;
    public float attackCooldown = 0f;
    bool attackOnCooldown = false;

    private bool isDead = false;

    private void Awake()
    {
        GameManager.Main.goblins.Add(this);
        animator.SetInteger("battle", 1);//default idle
        animator.SetInteger("moving", 2);//run
        GameManager.gameEnd += this.SetGameOverLogic;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && !GameManager.Main.gameIsOver)
        {           
            if (hasReachedTower)
            {
                Vector3 towardsTower = Vector3.RotateTowards(transform.forward, GameManager.Main.theTower.location, 2 * Mathf.PI, 0f);

                gameObject.transform.rotation = Quaternion.LookRotation(towardsTower);
                Attack();
            }
            else
            {
                agent.SetDestination(GameManager.Main.theTower.location);
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void Attack()
    {
        if (!attackOnCooldown)
        {
            animator.SetInteger("moving", Random.Range(3,5));
            attackCooldown = attackCdMax;           
            attackOnCooldown = true;
            reachedTower.TakeDamage(damage);
        }
        else
        {
            attackCooldown -= Time.deltaTime;
            if(attackCooldown <= 0)
            {
                animator.SetInteger("moving", 0);
                attackOnCooldown = false;
            }
        }
    }

    public void ReachedTower(Tower theTower)
    {
        if (!isDead)
        {
            reachedTower = theTower;
            agent.SetDestination(transform.position); // stop moving
            animator.SetInteger("moving", 0);
            hasReachedTower = true;
            attackOnCooldown = true;
        }

        
    }

    public void GetHit()
    {
        if (!isDead)
        {
            isDead = true;
            GameManager.Main.goblins.Remove(this);
            GameManager.Main.points++;
            animator.SetInteger("battle", 0);
            animator.SetInteger("moving", 13);
            StartCoroutine(WaitForDeath());
        }
        
        //Destroy(this.gameObject);
        //StartCoroutine(WaitForDeath());
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }

    private void SetGameOverLogic()
    {
        //animator.SetInteger("moving", 5);
        //animator.SetInteger("battle", 0);
        animator.SetInteger("moving", 0);
        StartCoroutine(SetWinAnimation());
    }

    private IEnumerator SetWinAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        animator.SetInteger("moving", 5);
    }
}
