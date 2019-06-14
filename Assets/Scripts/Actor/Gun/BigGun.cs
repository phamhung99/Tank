using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize(5);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        MoveOn();
    }
}
