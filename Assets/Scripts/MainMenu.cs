using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int unlockedLevels = 0;
    public Button[] levelButtons;
    private void Start()
    {
        unlockedLevels = PlayerPrefs.GetInt("Levels");
        Debug.Log($"Levels: {unlockedLevels}");

        for (int i=0;i<levelButtons.Length;i++)
        {
            levelButtons[i].interactable = (i <= unlockedLevels);
        }
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
