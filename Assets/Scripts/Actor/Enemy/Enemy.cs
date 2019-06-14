using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    int rotaOption;
    float timeMoveUp;
     float timeDelay;
    float deltaTime;
    private bool moveUp;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    public void InitEnemy(int speedRotation, float speed,int health, float timeDelay)
    {
        Initialize(speedRotation, speed, health);
        this.timeDelay = timeDelay;
        moveUp = true;
    }
   

    // Update is called once per frame
    void Update()
    {       
       
 
    }

    
    public void MoveRandom()
    {       
        if(Time.time > deltaTime + timeDelay)
        {
            deltaTime = Time.time;           
            rotaOption = Random.RandomRange(1,10);    
    
        }

        if (moveUp)
        {
            Moveverment(1);
        }
        else
        {
            Moveverment(-1);
        }

        if(rotaOption > 6)
        {
            RotationRight(true);
        }else if(rotaOption < 4)
        {
            RotationRight(false);
        }
        //Debug.Log(rotaOption);
        
        
    }


    /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Wall"))
        //{
            
            StartCoroutine(WaitMoveDown());
            //Debug.Log(moveUp);
        //}  
    }

    IEnumerator WaitMoveDown()
    {
        moveUp = false;
        rotaOption = 7;
        deltaTime = Time.time;  
        yield return new WaitForSeconds(1);
        moveUp = true;
    }

    
}
