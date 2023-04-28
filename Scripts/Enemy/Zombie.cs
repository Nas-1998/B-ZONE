using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    private NavMeshAgent agent = null;
    private Animator anim = null;
    private ZombieStats stats = null;
    private Transform target;

    //[SerializeField] private float stoppingDistance = 3;

    private float timeOfLastAttack = 0;
    private bool AttackStopped = false;
    private void Start()
    {
        GetReferences();
    }

    private void FixedUpdate()
    {
            MoveToTarget();      
    }

    private void MoveToTarget()
    {
            agent.SetDestination(target.position);
            anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
            RotateToTarget();

            float distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget <= agent.stoppingDistance)
            {
                anim.SetFloat("Speed", 0f);
                //attack
                if (!AttackStopped)
                {
                    AttackStopped = true;
                    timeOfLastAttack = Time.time;
                }

                if (Time.time >= timeOfLastAttack + stats.attackSpeed)
                {
                    timeOfLastAttack = Time.time;
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                    AttackTarget(targetStats);
                }
            }
            else
            {
                if (AttackStopped)
                {
                    AttackStopped = false;
                }
            }
        
        


    }


    private void RotateToTarget()
    {
        //transform.LookAt(target);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget(CharacterStats statsDamaged)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsDamaged);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<ZombieStats>();
        target = ThirdPersonController.instance;
    }

}
