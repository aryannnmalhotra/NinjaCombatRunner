using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private uint generateCount;
    private float currentPoint;
    public GameObject Blade;
    public GameObject Torch;
    public Transform NinjaPos;
    public static List<GameObject> obstacles = new List<GameObject>();
    private void Awake()
    {
        generateCount = 0;
        currentPoint = 10;
    }
    void Start()
    {
        InvokeRepeating("GenerateObstacles", 0, 1);
    }
    void GenerateObstacles()
    {
        if (Ninja.IsAlive)
        {
            generateCount++;
            if (generateCount % 7 != 0)
            {
                int decider = Random.Range(1, 11);
                if (decider == 2 || decider == 7 || decider == 9 || decider == 5)
                {
                    var go = Instantiate(Blade) as GameObject;
                    obstacles.Add(go);
                    go.transform.position = new Vector3(currentPoint, -0.25f, 0);
                    currentPoint += Random.Range(14, 18);
                }
                else if (decider == 1 || decider == 3 || decider == 4 || decider == 6 || decider == 8)
                {
                    var go = Instantiate(Torch) as GameObject;
                    obstacles.Add(go);
                    go.transform.position = new Vector3(currentPoint, -3.13f, 0);
                    currentPoint += Random.Range(14, 18);
                }
                else
                {

                }
            }
        }
    }
    void Update()
    {
        if (Ninja.IsAlive)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i] != null)
                {
                    if (NinjaPos.position.x - obstacles[i].transform.position.x > 3.3f)
                    {
                        var toDestroy = obstacles[i];
                        obstacles.RemoveAt(i);
                        Destroy(toDestroy);
                    }
                }
            }
        }
    }
}
