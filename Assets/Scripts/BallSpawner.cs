using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class BallSpawner : MonoBehaviour
{
    private RaycastHit2D ray;
    [SerializeField] private LayerMask _layerMask;
    private float angle;
    [SerializeField] private Vector2 minMaxAngle;
    
    private GameObject player;
    private GameObject bottom;
    private GameObject ballCountGameObject;
    private TextMeshProUGUI ballCountText;
    [SerializeField] private bool useRay;
    [SerializeField] private bool useLine;
    [SerializeField] private bool useDots;

    [SerializeField] private LineRenderer line;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float force;
    public  int ballCount;
    public int currentCount;

    public static bool ballActive;
    public float fastTime;

    private void Awake()
    {
        ballActive = true;
        currentCount = ballCount;
        ballCountGameObject = GameObject.FindGameObjectWithTag("ballCount");
        ballCountText = ballCountGameObject.GetComponent<TextMeshProUGUI>();
        player=GameObject.FindGameObjectWithTag("Player");
        bottom=GameObject.FindGameObjectWithTag("Bottom");
    }

    
    public void FixedUpdate()
    {
        if (ballActive==true)
        {
            this.gameObject.transform.position = player.transform.position;
            if (Input.GetMouseButton(0))
            {
                fastTime = 0;
                Time.timeScale = 1;
                ray = Physics2D.Raycast(transform.position, transform.up, 15f, _layerMask);
                //Debug.DrawRay(transform.position,ray.point,Color.red);


                Vector2 reflactPos =
                    Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;


                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

                if (angle >= minMaxAngle.x && angle <= minMaxAngle.y)
                {
                    if (useRay)
                    {
                        Debug.DrawRay(transform.position,transform.up * ray.distance,Color.red);
                        Debug.DrawRay(ray.point, reflactPos.normalized*2f,Color.green);
                    }

                    if (useLine)
                    {
                        line.SetPosition(0,transform.position);
                        line.SetPosition(1,ray.point);
                        line.SetPosition(2,ray.point+reflactPos.normalized*2f);
                    }

                    if (useDots)
                    {
                        Dots.instance.DrawDottedLine(transform.position,ray.point);
                        Dots.instance.DrawDottedLine(ray.point,ray.point+reflactPos.normalized*2f);
                    }
                
                
                }

                transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
            }

        }
        
        
        
    }

    public void Update()
    {
        Debug.Log(Time.timeScale);
        ballCountText.text = "x" + currentCount;
        if (Input.GetMouseButtonUp(0))
        {
            
            if (ballActive==true)
            {
                
                bottom.GetComponent<Bottom>().ballList.Clear();
                StartCoroutine(ShootBalls());
                bottom.GetComponent<Bottom>().crashCount = 0;
                ballActive = false;
            }
            
        }

        if (ballActive==false)
        {
            fastTime += Time.deltaTime;
            if (fastTime>=10)
            {
                
                Time.timeScale = 2f;
                
            }
        }
        
    }

    public IEnumerator ShootBalls()
    {
        for (int i = 0; i < ballCount; i++)
        {
            
            yield return new WaitForSeconds(0.08f);
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up*force);
            currentCount--;

        }
    }
}
