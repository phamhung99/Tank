using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        InitEnemy(1, 5, 75,3);
        EnemyController.instance.enemies.Add(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveRandom();
    }

    public override void Death()
    {
        EnemyController.instance.numMTank --;
    }
}
