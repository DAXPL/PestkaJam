using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instace;
    [SerializeField] private GameObject GameOverUI;
    Player player;
    void Start()
    {
        if (Instace != null) 
        {
            Debug.LogWarning("Too many managers!");
            Destroy(this);
        }
        else
        {
            Instace = this;
        }

        if (GameOverUI)
        {
            GameOverUI.SetActive(false);
        }
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerLost(bool stop = false)
    {
        Debug.Log("LOST!");
        if (player)
        {
            player.KillPlayer(stop);
        }
        if (GameOverUI)
        {
            GameOverUI.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restart!");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Debug.Log("Win!");
        player.KillPlayer();

        int levels = PlayerPrefs.GetInt("Levels");
        int thisLevel = SceneManager.GetActiveScene().buildIndex;
        if (levels < (thisLevel - 1))
        {
            levels = thisLevel-1;
            PlayerPrefs.SetInt("Levels", levels);
            PlayerPrefs.Save();
        }
        
        SceneManager.LoadSceneAsync(thisLevel + 1);
    }
}
