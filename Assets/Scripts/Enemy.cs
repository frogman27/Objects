using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : PlayableObject
{
    private EnemyType enemyType;

    protected Transform target; 

    [SerializeField] protected float speed;

    protected virtual void Start()
    {
        //find the player in the menu - this is the eternal target for the enemies
        //assign that position to the Transform object variable
        target = GameObject.FindWithTag("Player").transform;
    }

    //public void Update()
    //{
    //    //unsure why this is here?????
    //    switch (enemyType)
    //    {
    //        case EnemyType.Melee:
    //            Move(target.position);
    //            Attack(1f);
    //            break;
    //        case EnemyType.Exploder:
    //            Move(target.position);
    //            Shoot();
    //            break;
    //        case EnemyType.Shooter:
    //            Move(5.0f);
    //            Attack(1f);
    //            Shoot();
    //            break;
    //        case EnemyType.MachineGun:
    //            Move(target.position);
    //            Attack(0.5f);
    //            Shoot();
    //            break;
    //    }

    //}
    

    public override void Move(Vector2 direction, Vector2 target)
    {}

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot()
    {}

    public override void Attack(float interval)
    {}

    public override void Attack(Transform target)
    {

    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public override void GetDamage(float damage)
    {

    }
}
