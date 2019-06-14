using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnenmy : Enemy
{
    [SerializeField] private GameObject tfplayer;
    Vector2 dictationTarget;
    float angleDegree;
    // Start is called before the first frame update
    void Start()
    {
        tfplayer = GameObject.FindGameObjectWithTag("Player");
        EnemyController.instance.enemies.Add(gameObject); 
        Initialize(1, 3, 150);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tfplayer != null)
        {
            dictationTarget = tfplayer.transform.position - transform.position;
            angleDegree = Mathf.Atan2(dictationTarget.x, dictationTarget.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angleDegree, Vector3.back); 
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.03f);
            if (Mathf.Abs(Mathf.Abs(dictationTarget.x) + Mathf.Abs(dictationTarget.y)) > 5 )
            {
                Moveverment(1);
            }
        }
    
    }

    public override void Death()
    {
        EnemyController.instance.numBTank --;
    }
}
