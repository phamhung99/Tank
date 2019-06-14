using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public static GameObject currentPlayer;
    public bool inGame;

    public GameObject menuUI;
    public GameObject startUI;
    public GameObject gameOverUI;
    public static GameController instance;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        EnterLobby();
    }

    public void EnterLobby ()
    {
        Debug.Log("Menu Game");   
        menuUI.SetActive(true);
        startUI.SetActive(false);
        gameOverUI.SetActive(false);
        EnemyController.instance.ClearEnemies();
        inGame = false;
    }

    public void StartGame()
    {
        AudioManager.Play("Background");
        menuUI.SetActive(false);
        startUI.SetActive(true);
        gameOverUI.SetActive(false);

        inGame = true;
        Debug.Log("Start Game");
        

        currentPlayer = Instantiate(player, transform.position, transform.rotation);
        EnemyController.instance.StartEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (inGame && currentPlayer == null && !gameOverUI.activeInHierarchy)
        {
            inGame = false;
            //Debug.Log("Gameover");
            Invoke("GameOver", 1f);
        }
    }

    public void GameOver()
    {
        AudioManager.Stop("Background");
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
        startUI.SetActive(false);
        menuUI.SetActive(false);
        EnemyController.instance.spawn = false;
    }
    public void Quit ()
    {
        Application.Quit();
    }
}
