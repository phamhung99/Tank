using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerGun : Gun
{


    // Start is called before the first frame update
    void Start()
    {
        Initialize(0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        MousePos();
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
        
        MoveOn();

        //RotationToTarget(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition).y 
        //           + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition).z);

        
    }

    public void MousePos()
    {
        Vector3 mousePosFar = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 f = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 n = Camera.main.ScreenToWorldPoint(mousePosNear);
        
        RotationToTarget(f);
        Debug.DrawRay(n, f- n, Color.green);
    }

 

}
