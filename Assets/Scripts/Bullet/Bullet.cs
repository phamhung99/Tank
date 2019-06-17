using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;

    [SerializeField] GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("SmallBullet"))
        {
            damage = 10;
            speed = 20f;
        }else
        {
            if (gameObject.CompareTag("MediumBullet"))
            {
                damage = 10;
                speed = 25;
            }else
            {
                if (gameObject.CompareTag("BigBullet"))
                {
                    damage = 20;
                    speed = 30;
                }else
                {
                    damage = 25;
                    speed =25;
                }
            }
        }
        
    }

    public void Initialization (int damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }

    public void MoveUp()
    {
        transform.Translate(Vector3.up*Time.deltaTime*speed);
    }


    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Dameage");
            Actor targetHit = other.gameObject.GetComponent(typeof(Actor)) as Actor;
            if (targetHit != null)
            {
                targetHit.Damage(damage);
            }
        }
        Instantiate (explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
