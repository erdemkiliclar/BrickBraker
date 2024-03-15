using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    private BallSpawner _ballSpawner;

    private void Awake()
    {
        _ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
    }

    private void Update()
    {
        if (_ballSpawner.fastTime>=10)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
    }
}
