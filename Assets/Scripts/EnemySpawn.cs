using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float currentPoint;
    public GameObject Alpha;
    public GameObject Beta;
    public Transform NinjaPos;
    public static List<GameObject> AlphaE = new List<GameObject>();
    public static List<GameObject> BetaE = new List<GameObject>();
    private void Awake()
    {
        currentPoint = 80;
    }
    void Start()
    {
        InvokeRepeating("Spawn",0,1);
    }
    void Spawn()
    {
        if (Ninja.IsAlive)
        {
            int decider = Random.Range(1, 7);
            for (int i = 0; i < 2; i++)
            {
                if (decider == 1 || decider == 5)
                {
                    var go = Instantiate(Alpha) as GameObject;
                    AlphaE.Add(go);
                    go.transform.position = new Vector3(currentPoint, -2.4f, 0);
                    currentPoint += Random.Range(3.6f, 10);
                }
                else if (decider == 2 || decider == 3 || decider == 4)
                {
                    var go = Instantiate(Beta) as GameObject;
                    BetaE.Add(go);
                    go.transform.position = new Vector3(currentPoint, -2.4f, 0);
                    currentPoint += Random.Range(3.6f, 10);
                }
                else
                    currentPoint += Random.Range(3.6f, 10);
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < AlphaE.Count; i++)
        {
            if (AlphaE[i] != null)
            {
                if (NinjaPos.position.x > AlphaE[i].transform.position.x)
                    AlphaE[i].transform.rotation = new Quaternion(0, 0, 0, 0);
                if (NinjaPos.position.x - AlphaE[i].transform.position.x > 4.3f)
                {
                    var toDestroy = AlphaE[i];
                    AlphaE.RemoveAt(i);
                    Destroy(toDestroy);
                }
            }
            else
            {

            }
        }
        for (int i = 0; i < BetaE.Count; i++)
        {
            if (BetaE[i] != null)
            {
                if (NinjaPos.position.x > BetaE[i].transform.position.x)
                    BetaE[i].transform.rotation = new Quaternion(0, 0, 0, 0);
                if (NinjaPos.position.x - BetaE[i].transform.position.x > 4.3f)
                {
                    var toDestroy = BetaE[i];
                    BetaE.RemoveAt(i);
                    Destroy(toDestroy);
                }
            }
            else
            {

            }
        }
    }
}
