using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    [SerializeField] private float attackRange;

    [SerializeField] private float attackTime = 0;

    private float timer = 0;

    protected override void Start()
    {
        //base is just the virtual class that it is inheriting from????
        base.Start();
        health = new Health(1, 0, 1);
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
    }

    private void Update()
    {
        Attack(target);
    }
    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            //inheritted from parent script
            target.GetComponent<IDamageable>().GetDamage(0);
        }
    }

    public override void Attack(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetMeleeEnemy(float _attackRange, float _attackTime)
    {
        attackRange = _attackRange;
        attackTime = _attackTime;   
    }
}
