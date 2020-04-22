using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    private uint bgCount;
    private uint chainCount;
    private uint generateCount;
    private List<GameObject> chain = new List<GameObject>();
    private List<GameObject> bg = new List<GameObject>();
    public GameObject MainCamera;
    public GameObject Bg;
    public GameObject Chain;
    public Transform NinjaPos;
    private void Awake()
    {
        bgCount = 0;
        chainCount = 0;
        generateCount = 0;
    }
    void Start()
    {
        GenerateEnvironment();
        InvokeRepeating("GenerateEnvironment", 0, 2.5f);
    }
    void GenerateEnvironment()
    {
        if (Ninja.IsAlive)
        {
            generateCount++;
            if (generateCount % 7 != 0)
            {
                var go = Instantiate(Bg) as GameObject;
                go.transform.position = Bg.transform.position + new Vector3(bgCount++ * (1.78f * 10), 0, 0);
                bg.Add(go);
            }
            if (generateCount % 5 != 0)
            {
                for (int i = 0; i < 13; i++)
                {
                    var go1 = Instantiate(Chain) as GameObject;
                    go1.transform.position = Chain.transform.position + new Vector3(chainCount++ * (0.28721f * 8.49f), 0, 0);
                    chain.Add(go1);
                }
            }
        }
    }
    void Update()
    {
        if(Ninja.IsAlive)
           MainCamera.transform.position = MainCamera.transform.position + new Vector3(5.5f * Time.deltaTime, 0.0f, 0.0f);
        for (int i= 0; i < bg.Count; i++)
        {
            if (NinjaPos.position.x - bg[i].transform.position.x > 20)
            {
                var toDestroy = bg[i];
                bg.RemoveAt(i);
                Destroy(toDestroy);
            }
        }
        for (int i = 0; i < chain.Count; i++)
        {
            if (NinjaPos.position.x - chain[i].transform.position.x > 18)
            {
                var toDestroy = chain[i];
                chain.RemoveAt(i);
                Destroy(toDestroy);
            }
        }
    }
}
