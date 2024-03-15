using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallsColor : MonoBehaviour
{
    private ColorArray _colorArray;
    [SerializeField] private GameObject top;
    
    private void Awake()
    {
        _colorArray = GameObject.FindGameObjectWithTag("Main").GetComponent<ColorArray>();
        int x;
        x = Random.Range(0, _colorArray.colors.Length);
        gameObject.GetComponent<SpriteRenderer>().color = _colorArray.colors[x];
    }


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = top.GetComponent<SpriteRenderer>().color;
    }
}
