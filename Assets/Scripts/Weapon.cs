using UnityEngine;
using UnityEngine.Rendering;

public class Weapon
{
    private string name;
    private float damage;
    private float bulletSpeed;


    

    public Weapon(string _name, float _damage, float _bulletSpeed)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public Weapon(){}

    public void Shoot(Bullet _bullet, PlayableObject _player, string _target, float _timeToDie=5)
    {
        Bullet tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        Debug.Log("Weapon is shooting");
        GameObject.Destroy(tempBullet.gameObject, _timeToDie);
    }

    public float GetDamage()
    {
        return damage;
    }
}
