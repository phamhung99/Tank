using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    bool findPlayer;
    bool rota;
    [SerializeField] GameObject tfPlayer;
    // Start is called before the first frame update
    void Start()
    {
        tfPlayer = GameObject.FindGameObjectWithTag("Player");
        rota = false;
        findPlayer = false;
        Initialization(20,13);
        Invoke("SetRota", 0.2f);
        Invoke("SetFindPlayer", 2);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        if (rota)
        {
            transform.Rotate(0,0,10);
        }
        if (findPlayer)
        {
            MovetoPlayer();
        }
        
    }

    void MovetoPlayer()
    {
        if (tfPlayer != null)
        {
            Vector2 dictationTarget = tfPlayer.transform.position - transform.position;
            float angleDegree = Mathf.Atan2(dictationTarget.x, dictationTarget.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angleDegree, Vector3.back); 
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f);
        }
        
    }

    void SetFindPlayer()
    {
        findPlayer =true;
        rota = false;
    }

    void SetRota()
    {
        rota = true;
    }


}
