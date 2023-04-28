using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    public float attackSpeed;

    Animator anim;

    //[SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariables();
        anim = GetComponent<Animator>();
    }

    public void DealDamage(CharacterStats statsDamaged)
    {
        statsDamaged.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        anim.SetTrigger("death");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 0.5f);
    }


    public override void InitVariables()
    {
        maxHealth = 50;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 0.7f;
        //canAttack = true;


    }
}
