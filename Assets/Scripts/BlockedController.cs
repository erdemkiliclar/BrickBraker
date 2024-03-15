using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedController : MonoBehaviour
{
    GameObject _goPanel;


    private void Awake()
    {
        _goPanel = GameObject.FindGameObjectWithTag("Main").GetComponent<PanelController>().goPanel;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Block"))
        {
            _goPanel.SetActive(true);
        }
    }
}
