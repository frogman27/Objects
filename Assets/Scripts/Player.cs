using System;
using UnityEngine;

public class Player : PlayableObject
{
    [SerializeField] private Camera cam;
    [SerializeField] protected float speed;

    [SerializeField] private float weaponDamage=1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPreFab;

    public Action<float> OnHealthUpdate;

    private Rigidbody2D playerRB;

    private void Start()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();
        health.RegenHealth();

        //Set The Player Weapon
        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        OnHealthUpdate?.Invoke(health.GetHealth());
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime;

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        //what does this do????
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    private void Update()
    {
        health.RegenHealth();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        //where is this supposed to be called from?
            Debug.Log(this.tag.ToString() + "is shooting");
            weapon.Shoot(bulletPreFab, this, "Enemy");
    }

    public override void Attack(Transform target)
    {

    }
    public override void Die()
    {}




}
