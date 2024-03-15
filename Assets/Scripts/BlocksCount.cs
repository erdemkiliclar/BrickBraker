using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksCount : MonoBehaviour
{
    public int _blockCount;
    private GameObject victoryPanel;
    private GameObject _victoryPart;
    
    private void Awake()
    {
        
        victoryPanel = GameObject.FindGameObjectWithTag("Main").GetComponent<PanelController>()._victoryPanel;
        _blockCount = gameObject.transform.childCount;
    }

    private void Update()
    {
        if (_blockCount==0)
        {
           victoryPanel.SetActive(true);
           
        }

        
    }
}
