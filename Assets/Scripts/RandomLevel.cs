using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomLevel : MonoBehaviour
{
    
    public int levelIndex;
    NextLevel _nextLevel;
    public static int _currentLevel;


    public GameObject[] _levels;


    public void Awake()
    {
        
        _nextLevel = GetComponent<NextLevel>();
        PlayerPrefs.GetInt("Level", _nextLevel._level);
        PlayerPrefs.GetInt("CurrentLevel", levelIndex);
        
        
    }

    private void Update()
    {
        Debug.Log(GameOver.gameOver);
    }

    public void Start()
    {
        LoadPlane();
    }

    public void LevelInstantiate()
    {
    
        if (GameOver.gameOver==true)
        {
            Instantiate(_levels[PlayerPrefs.GetInt("CurrentLevel", levelIndex)], new Vector3(0, 0, 0), transform.rotation);
        }
        else
        {
            levelIndex = Random.Range(0, _levels.Length);
            PlayerPrefs.SetInt("CurrentLevel", levelIndex);
            Instantiate(_levels[levelIndex], new Vector3(0, 0, 0), transform.rotation);
        }

    }

    private void LoadPlane()
    {
        if (GetComponent<NextLevel>()._level >= _levels.Length)
        {
            LevelInstantiate();
        }
        else
        {
            Instantiate(_levels[GetComponent<NextLevel>()._level], new Vector3(0, 0, 0), transform.rotation);
        }
    }
}
