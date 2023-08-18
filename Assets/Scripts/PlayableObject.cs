using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//why is this an abstract class?
//understand its purpose
public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health health = new Health();

    public Weapon weapon;

    public virtual void Move(Vector2 direction, Vector2 target)
    {}

    public virtual void Move(Vector2 direction)
    {}

    public virtual void Move(float speed)
    {}

    public virtual void Shoot()
    {}

    public virtual void Attack(float interval)
    {
        Debug.Log($"Attacking");
    }

    public abstract void Attack(Transform target);

    public abstract void Die();

    public virtual void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
            Die();
    }

    public void GetDamage(int speed)
    {
        if (speed > 10)
            health.DeductHealth(10);
        else
            health.DeductHealth(speed);
    }
}
