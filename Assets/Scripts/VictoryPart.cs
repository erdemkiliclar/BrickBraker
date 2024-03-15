using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPart : MonoBehaviour
{
    private GameObject _victoryPart;

    private void Awake()
    {
        _victoryPart = GameObject.FindGameObjectWithTag("VictoryPart");
        
    }

    private void Start()
    {
        _victoryPart.GetComponent<ParticleSystem>().Play();
    }
}
