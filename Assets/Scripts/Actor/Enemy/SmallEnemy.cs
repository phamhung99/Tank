using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        InitEnemy(2,8, 59,3);
        EnemyController.instance.enemies.Add(gameObject); 
        
    }


    // Update is called once per frame
    void Update()
    {

        MoveRandom();
    }
    public override void Death()
    {
        EnemyController.instance.numSTank --;
    }
}
