using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Initialize(2f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        Shoot();
        MoveOn();
        RotationToTarget(player.transform.position);
    }
}
