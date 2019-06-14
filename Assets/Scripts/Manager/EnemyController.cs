using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject smallTank;
    public GameObject mediumTank;
    public GameObject bigTank;


    public List<GameObject> enemies;
    public static EnemyController instance;

    float totalTime;

    float maxSTank = 6;
    float maxMTank = 4;
    float maxBTank = 2;

    public float numSTank;
    public float numMTank;
    public float numBTank;

    float sTimer;
    float sNewTime = 7;
    float sMinTime = 3;

    float mTimer;
    float mNewTime = 10;
    float mMinTime = 4;

    float bTimer;
    float bNewtime = 15;
    float bMinTime = 6;

    public bool spawn;

    
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        instance = this;
        ResetTimer();
        
    }

    public void StartEnemy()
    {
        ClearEnemies();
        ResetTimer();
        enemies = new List<GameObject>();

        spawn = true;

    }

    void ResetTimer()
    {
        
        totalTime = 0;
        sTimer = 0;
        mTimer = 0;
        bTimer = 0;

        sNewTime = 10;
        mNewTime = 15;
        bNewtime = 20;

        numBTank = 0;
        numMTank = 0;
        numSTank = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn) return;
        

        totalTime += Time.deltaTime;

        if (totalTime < 1) return;
        sTimer -= Time.deltaTime;
        if (sTimer < 0) SpawnSmallEnemy();

        if (totalTime < 7) return;
        mTimer -=Time.deltaTime;
        if (mTimer < 0) SpawnMediumEnemy();

        if (totalTime < 15) return;
        bTimer -= Time.deltaTime;
        if (bTimer < 0) SpawnBigEnemy();
    

        
    }

    void SpawnEnemy(GameObject enemy)
    {
        float x = Random.Range(-14, 14);
        float y = Random.Range(-14, 14);
        Vector2 spawnPos = new Vector2 (x,y);

        Instantiate(enemy, spawnPos, transform.rotation);
    }

    void SpawnSmallEnemy()
    {
        if(sNewTime > sMinTime) sNewTime -= 0.2f;
        sTimer = sNewTime;
        
        if (numSTank >= maxSTank) return;

        numSTank ++;
        
        SpawnEnemy(smallTank);
    }

    void SpawnMediumEnemy()
    {
        if(mNewTime > mMinTime) mNewTime -= 0.2f;
        mTimer = mNewTime;

        if (numMTank >= maxMTank) return;

        numMTank ++;

        SpawnEnemy(mediumTank);
    }

    void SpawnBigEnemy()
    {
        if (bNewtime > bMinTime) bNewtime -= 0.2f;
        bTimer = bNewtime;

        if (numBTank >= maxBTank) return;

        numBTank ++;

        SpawnEnemy(bigTank);
    }

    public void ClearEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }
        numBTank = 0;
        numMTank = 0;
        numSTank = 0;
    }
}
