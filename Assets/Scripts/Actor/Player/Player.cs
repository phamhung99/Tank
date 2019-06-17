using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public static Player instance;
    public GameObject explode;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Initialize(3, 10, 200);
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
        SoundMove();
    }

    void FixedUpdate()
    {             
        MovementPlayer();
    }

    public override void Kill()
    {
        Instantiate(explode, transform.position, transform.rotation);
        base.Kill();
    }

    void MovementPlayer()
    {

        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            Moveverment(1);
            if (Input.GetKey(KeyCode.A))
            {
                RotationRight(false);
            }else if (Input.GetKey(KeyCode.D))
            {
                RotationRight(true);
            }
            return;
            
        }else if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            Moveverment(-1);
            if (Input.GetKey(KeyCode.A))
            {
                RotationRight(true);
            }else if (Input.GetKey(KeyCode.D))
            {
                RotationRight(false);
            }
            return;
        }
            moving =false;
    }

}
