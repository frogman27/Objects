using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float damage;

    private string targetTag;

    private void Start()
    {
        //this doesn't work because it's 3D
        //transform.LookAt(GameObject.FindWithTag("Player").transform);
    }

    public void SetBullet(float _damage, string _targetTag, float speed)
    {
        this.damage = _damage;
        this.speed = speed;
        this.tag = _targetTag;
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);
            //LevelLoader.Score++;
            Destroy(gameObject); 
        }
        Debug.Log("Bullet damaged target");
        //damage target
    }
}
