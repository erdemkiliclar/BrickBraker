using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bottom : MonoBehaviour
{
    public List<GameObject> ballList = new List<GameObject>();
    GameObject _player;
    public int crashCount;
    private GameObject _ballSpawner;
    private GameObject blocks;
    private GameObject nextTransform;
    private void Awake()
    {
        crashCount = 0;
        _ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner");
        _player = GameObject.FindGameObjectWithTag("Player");
        blocks = GameObject.FindGameObjectWithTag("Blocks");
        nextTransform = GameObject.FindGameObjectWithTag("NextTransform");
        nextTransform.transform.position = _player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            
            if (crashCount<1)
            {
                nextTransform.transform.position = col.gameObject.transform.position;
                
                ballList.Add(col.gameObject);
                crashCount++;
                col.gameObject.transform.position = _player.transform.position;
                Destroy(col.gameObject);
            }

            if (crashCount>=1)
            {
                ballList.Add(col.gameObject);
                Destroy(col.gameObject);
                if (ballList.Count==_ballSpawner.GetComponent<BallSpawner>().ballCount+1)
                {

                    _player.transform.DOMove(new Vector3(nextTransform.transform.position.x,-3.86f,nextTransform.transform.position.z), 1f).OnComplete((() =>
                        BallSpawner.ballActive = true
                            ));
                    
                    blocks.transform.position = new Vector3(blocks.transform.position.x, blocks.transform.position.y-0.5f);
                    
                    
                }
                _ballSpawner.GetComponent<BallSpawner>().currentCount++;
            }

            
            
            
        }
    }
}
