using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused=false;
    bool gameOver = false;
    [SerializeField] GameObject canvaspausa;
    [SerializeField] GameObject canvasnivel;
    [SerializeField] Nave player;
    [SerializeField] int numEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        canvaspausa.SetActive(false);
        canvasnivel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P )&& gameOver== false)
            PauseGame();
    }
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }
    void PauseGame ()

    {
        gamePaused = gamePaused ? false : true;
        player.gamePaused = gamePaused;
        canvaspausa.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0 : 1;    
    }

    public void ReducirNumEnemies ()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies < 1)
        {
            Pasarnivel();
        }
    }

    public void Pasarnivel ()
    {
        canvasnivel.SetActive(true);
        player.gamePaused = true;
        Time.timeScale = 0;

    }
    public void Signiv (int nivel)
    {
        player.gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(nivel);
    }
 }

