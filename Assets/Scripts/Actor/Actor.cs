using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] float speed;
    public float health ;

    [SerializeField] int speedRotation;
    public bool moving;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        moving =false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int speedRotation, float speed, int health)
    {
        this.speedRotation = speedRotation;
        this.speed = speed;
        this.health = health;
    }


    public void Moveverment(float s)
    {
        if (s > 0)
        {
            
            transform.Translate(Vector3.up*Time.deltaTime*speed);

        }else
        {   
          
            transform.Translate(Vector3.down*Time.deltaTime*speed/2);
        }
        
    }

    public void RotationRight(bool check)
    {
        if (check)
        {                            
            transform.Rotate(new Vector3(0,0,-speedRotation)); 
        }
        else
        {
            transform.Rotate(new Vector3(0,0,speedRotation)); 
        }
    }
    public void SoundMove()
    {
        if(moving && !AudioManager.CheckPlaying("Move"))
        {
            AudioManager.Play("Move");
        }else
        {
            if(!moving) AudioManager.Stop("Move");
        }
    }
    

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
            if (gameObject.CompareTag("Enemy"))
            {
                ScoreController.instance.AddScore(100);
            }
        }
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
        Death();
        
    }

    public virtual void Death()
    {
        //Debug.Log("hihi");
    }

}
