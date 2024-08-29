using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Button[] levelButtons; 
    public Image[] lockImages; 
    public string levelSelect = "levelSelect";
    public string unlocklevel = "unlocklevel";
    public string score = "score";

    void Start()
    {
        if (!PlayerPrefs.HasKey(unlocklevel)) {
            PlayerPrefs.SetInt(unlocklevel, 1);
        }
        LoadLevelLocks(PlayerPrefs.GetInt(unlocklevel, 1));
        
       //PlayerPrefs.DeleteAll();
    }

    void LoadLevelLocks(int index)
    {
        for (int i = index; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            lockImages[i].gameObject.SetActive(true);
        }
    }
    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt(levelSelect, level);
        SceneManager.LoadScene("Game");
    }
}