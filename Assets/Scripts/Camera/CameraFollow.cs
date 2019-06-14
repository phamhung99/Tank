using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        posX = 0; 
        posY = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameController.instance.inGame || GameController.currentPlayer == null) return;
        
        posY = GameController.currentPlayer.transform.position.y;

        if (posY < -8) posY = -8;
        else if(posY > 8) posY =8;


        transform.position = new Vector3 (posX, posY, -20);

        
        
    }
}
