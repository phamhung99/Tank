using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   
    float angleDegree;
    bool checkRecoi;
    float timeStopShooting;
    float realTimme;
    private Vector2 dictationTarget;
    public GameObject bullet;
    [SerializeField] private Transform transformBullet;
    [SerializeField] private Transform positionLerp;
    

    // Start is called before the first frame update
    void Start()
    {
        checkRecoi = false;
        timeStopShooting = 0.3f;
        realTimme =0;
    }

    public void Initialize(float timeStopShooting )
    {
        this.timeStopShooting = timeStopShooting;
        

    }

    // Update is called once per frame


    

    public void RotationToTarget(Vector3 tf)
    {
        
        dictationTarget = tf - transform.position;
        angleDegree = Mathf.Atan2(dictationTarget.x, dictationTarget.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.back); 
       
    }

    public void Shoot()
    {

        if (Time.time > (realTimme + timeStopShooting))
        {
            AudioManager.Play("Shoot");
            realTimme = Time.time;
            
            transform.Translate(Vector3.down*0.2f);
            StartCoroutine(Wait());  
            Instantiate(bullet, transformBullet.position, transformBullet.rotation);
            
        }
    }

    IEnumerator Wait()
    {
        checkRecoi = false;
        yield return new WaitForSeconds(0.1f);
        checkRecoi = true;        
        yield return new WaitForSeconds(0.1f);
        checkRecoi = false;
        
        
    }

    public void MoveOn()
    {
        if(checkRecoi == true)
        {
            transform.position = Vector3.Lerp(transform.position, positionLerp.position, 0.8f);
        }
        
    }
 
}
