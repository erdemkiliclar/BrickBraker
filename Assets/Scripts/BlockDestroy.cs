using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxCountText;
    [SerializeField] int boxCount;
    [SerializeField] private Animator _animator;
    private GameObject main;
    private ColorArray _colorArray;
    private GameObject blocksV;
    
    private void Awake()
    {
        main = GameObject.FindGameObjectWithTag("Main");
        _colorArray = main.GetComponent<ColorArray>();
        blocksV = GameObject.FindGameObjectWithTag("BlocksV");
        
    }

    private void Start()
    {
        
        int x;
        x = Random.Range(0, _colorArray.colors.Length);
        gameObject.GetComponent<SpriteRenderer>().color = _colorArray.colors[x];
    }


    private void Update()
    {
        boxCountText.text = "" + boxCount;
        if (boxCount<=5)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            boxCount--;
            _animator.Play("block");
            if (boxCount==0)
            {
                blocksV.GetComponent<BlocksCount>()._blockCount--;
                Destroy(this.gameObject);
            }
        }
    }
}
