using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isAlive;
    private float Health;
    private Animator anim;
    private GameObject NinjaP;
    private GameObject hB;
    public bool isAlpha;
    public GameObject Bullet;
    public GameObject Rocket;
    public GameObject HB;
    private void Awake()
    {
        isAlive = true;
        Health = 100;
        anim = GetComponent<Animator>();
        NinjaP = GameObject.FindWithTag("Player");
    }
    void HealthBar()
    {
        if (hB != null && Health!=100)
        {
            hB.transform.GetChild(0).localScale = new Vector3(Health / 100, 1, 1);
            hB.transform.GetChild(0).localPosition = new Vector3(-((1 - (Health / 100)) * 0.9f) + 0.02f, 0, 0);
        }
    }
    
    public float GetHealth()
    {
        return Health;
    }
    public void SetHealth(float newHealth)
    {
        Health = newHealth;
        if (Health > 0)
        {
            CancelInvoke("HurtReset");
            anim.SetBool("Hurt", true);
            Invoke("HurtReset", 0.6f);
        }
    }
    void HurtReset()
    {
        anim.SetBool("Hurt", false);
    }
    void Start()
    {
        hB = Instantiate(HB) as GameObject;
        hB.transform.position = new Vector3(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y + 1.7f, 0);
        InvokeRepeating("Shoot", 0, 1);
    }
    void Shoot()
    {
        if (Ninja.IsAlive && !Ninja.IsJump && isAlive)
        {
            if(this.gameObject.transform.position.x - NinjaP.transform.position.x < 13.2f)
            {
                if (isAlpha)
                {
                    int decider = Random.Range(1, 4);
                    if(decider==1 || decider == 2)
                    {
                        anim.SetBool("Hurt", false);
                        anim.SetBool("Shoot", true);
                        Invoke("ShootReset", 0.4f);
                        var go = Instantiate(Rocket) as GameObject;
                        go.transform.position = new Vector3(this.gameObject.transform.position.x - 3, -2.99f,0);
                    }
                }
                else
                {
                    int decider = Random.Range(1, 4);
                    if (decider == 1 || decider == 2)
                    {
                        anim.SetBool("Hurt", false);
                        anim.SetBool("Shoot", true);
                        Invoke("ShootReset", 0.4f);
                        var go = Instantiate(Bullet) as GameObject;
                        go.transform.position = new Vector3(this.gameObject.transform.position.x - 2.3f, -2.98f, 0);
                    }
                }
            }
        }
    }
    void ShootReset()
    {
        anim.SetBool("Shoot", false);
    }
    void ToDestroy()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        HealthBar();
        if (Health == 0)
        {
            isAlive = false;
            anim.SetBool("Hurt", false);
            this.gameObject.transform.position += new Vector3(1.5f, 0, 0);
            anim.SetBool("Die", true);
            Invoke("ToDestroy", 0.6f);
            Destroy(hB);
        }
    }
}
