using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI _levelCountText;
    public int _level;
    

    private void Awake()
    {
        
        
        _level = PlayerPrefs.GetInt("Level", _level);
    }
    
    private void Start()
    {
        //TinySauce.OnGameStarted(_level.ToString());
        int currentLevel = _level + 1;

        _levelCountText.text = "LEVEL: " + currentLevel;
    }

    public void NextLevelButton()
    {
        _level = _level + 1;
        GameOver.gameOver=false;
        //TinySauce.OnGameFinished(true, 0,_level.ToString());
        PlayerPrefs.SetInt("Level", _level);
        SceneManager.LoadScene(0);
    }
}
