﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplenishableSpawn : MonoBehaviour
{
    private float currentPoint;
    public GameObject Health;
    public GameObject Star;
    public GameObject Kunai;
    public Transform NinjaPos;
    public static List<GameObject> replenishables = new List<GameObject>();
    private void Awake()
    {
        currentPoint = 14;
    }
    void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }
    void Spawn()
    {
        if (Ninja.IsAlive)
        {
            int decider = Random.Range(1, 9);
            for (int i = 0; i < 2; i++)
            {
                if (decider == 1 || decider == 5 || decider == 6)
                {
                    var go = Instantiate(Health) as GameObject;
                    replenishables.Add(go);
                    go.transform.position = new Vector3(currentPoint, 0.5f, 0);
                    currentPoint += Random.Range(7.5f, 9.5f);
                }
                else if (decider == 2 || decider == 3)
                {
                    var go = Instantiate(Kunai) as GameObject;
                    replenishables.Add(go);
                    go.transform.position = new Vector3(currentPoint, 0.5f, 0);
                    currentPoint += Random.Range(7.5f, 9.5f);
                }
                else if (decider == 7 || decider == 4)
                {
                    var go = Instantiate(Star) as GameObject;
                    replenishables.Add(go);
                    go.transform.position = new Vector3(currentPoint, 0.5f, 0);
                    currentPoint += Random.Range(7.5f, 9.5f);
                }
                else
                {
                    currentPoint += Random.Range(7.5f,9.5f);
                }
            }
        }
    }
    void Update()
    {
        if (Ninja.IsAlive)
        {
            for (int i = 0; i < replenishables.Count; i++)
            {
                if (replenishables[i] != null)
                {
                    if (NinjaPos.position.x - replenishables[i].transform.position.x > 3.5f)
                    {
                        var toDestroy = replenishables[i];
                        replenishables.RemoveAt(i);
                        Destroy(toDestroy);
                    }
                }
            }
        }
    }
}
