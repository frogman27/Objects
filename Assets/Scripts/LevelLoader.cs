using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private Player player = new Player();

    Enemy enemy1 = new Enemy();
    Enemy enemy2 = new Enemy();

    Weapon weapon1 = new Weapon();
    //use this once the weapon types are set
    //Weapon weapon2 = new Weapon("Assault Rifle", 50f);
    Weapon machineGun = new Weapon();

    EnemyType enemyType1 = new EnemyType();
    EnemyType enemyType2 = EnemyType.Melee;

    EnemyType enemyType3 = EnemyType.MachineGun;
    // Start is called before the first frame update
    void Start()
    {

        player.weapon = weapon1;
        enemy1.weapon = machineGun;
        //use this once weapon types are set
        //enemy2.weapon = weapon2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
