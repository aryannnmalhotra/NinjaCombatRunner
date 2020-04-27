using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    private Animator anim;
    private AudioSource soundPlayer;
    private bool isSlide;
    private bool isThrow;
    private bool isTouching;
    private bool toCheckTouch;
    private float touchStart;
    private float touchEnd;
    private Touch touch;
    public GameObject Star;
    public GameObject Kunai;
    public static float Health;
    public static float HealthLastChecked;
    public static int StarCount;
    public static int KunaiCount;
    public static bool IsJump;
    public static bool IsAlive;
    public float Force;
    public Rigidbody2D Ninjaa;
    public UIManager UI;
    public AudioClip StarSound;
    public AudioClip KunaiSound;
    public AudioClip Hurt;
    public AudioClip ReplenishableSound;
    private void Awake()
    {
        isSlide = false;
        isThrow = false;
        isTouching = false;
        toCheckTouch = false;
        IsJump = false;
        Health = 100;
        HealthLastChecked = Health;
        StarCount = 30;
        KunaiCount = 20;
        IsAlive = true;
        anim = GetComponent<Animator>();
        soundPlayer = GetComponent<AudioSource>();
        UI.HealthBar();
    }
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            IsJump = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            Health = Mathf.Clamp(Health - 100, 0, 100);
        if (collision.gameObject.CompareTag("Scorer"))
            UIManager.Score += 10;
        if (collision.gameObject.CompareTag("Replenishable"))
            soundPlayer.PlayOneShot(ReplenishableSound);
    }
    void JumpReset()
    {
        anim.SetBool("Jump", false);
    }
    void ThrowKunai()
    {
        Invoke("ThrowReset", 0.15f);
        var go = Instantiate(Kunai) as GameObject;
        go.transform.position = new Vector3(Ninjaa.transform.position.x + 2.5f, Ninjaa.transform.position.y + 0.2f, 0);
        soundPlayer.PlayOneShot(KunaiSound);
        KunaiCount = Mathf.Clamp(KunaiCount - 1, 0, 20);
        isThrow = false;
    }
    void ThrowStar()
    {
        Invoke("ThrowReset", 0.15f);
        var go = Instantiate(Star) as GameObject;
        go.transform.position = new Vector3(Ninjaa.transform.position.x + 1.8f, Ninjaa.transform.position.y + 0.1f, 0);
        soundPlayer.PlayOneShot(StarSound);
        StarCount = Mathf.Clamp(StarCount - 1, 0, 30);
        isThrow = false;
    }
    void ThrowReset()
    {
        anim.SetBool("Throw", false);
    }
    void SlideReset()
    {
        anim.SetBool("Slide", false);
        isSlide = false;
    }
    public void TStar()
    {
        if (StarCount > 0 && !isThrow) 
        {
            isThrow = true;
            CancelInvoke("ThrowReset");
            anim.SetBool("Throw", true);
            Invoke("ThrowStar", 0.3f); 
        }
    }
    public void TKunai()
    {
        if (KunaiCount > 0 && !isThrow)
        {
            isThrow = true;
            CancelInvoke("ThrowReset");
            anim.SetBool("Throw", true);
            Invoke("ThrowKunai", 0.3f);
        }
    }
    void Update()
    {
        if (IsAlive)
        {
            if(HealthLastChecked > Health)
            {
                soundPlayer.PlayOneShot(Hurt);
                HealthLastChecked = Health;
            }
            Ninjaa.transform.position = Ninjaa.transform.position + new Vector3(5.5f * Time.deltaTime, 0.0f, 0.0f);
            if (Input.GetKeyDown(KeyCode.W)&&!IsJump&&!isSlide)
            {
                CancelInvoke("JumpReset");
                IsJump = true;
                anim.SetBool("Jump", true);
                Ninjaa.AddForce(new Vector2(0, Force *10));
                Invoke("JumpReset", .5f);
            }
            if (Input.GetKeyDown(KeyCode.S) && !IsJump && !isSlide)
            {
                isSlide = true;
                anim.SetBool("Slide", true);
                Invoke("SlideReset", 1);
            }
            UI.HealthBar();
            if (Health == 0)
            {
                anim.SetBool("Die", true);
                IsAlive = false;
                Ninjaa.transform.position = new Vector3(Ninjaa.transform.position.x, -2.4f, 0);
            }
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touchStart = touch.position.y;
                    touchEnd = touch.position.y;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    touchEnd = touch.position.y;
                    if (Mathf.Abs(touchStart - touchEnd) >= 10)
                    {
                        if (touchStart > touchEnd)
                        {
                            if (!IsJump && !isSlide)
                            {
                                isSlide = true;
                                anim.SetBool("Slide", true);
                                Invoke("SlideReset", 1);
                            }
                        }
                        else if (touchStart < touchEnd)
                        {
                            if (!IsJump && !isSlide)
                            {
                                CancelInvoke("JumpReset");
                                IsJump = true;
                                anim.SetBool("Jump", true);
                                Ninjaa.AddForce(new Vector2(0, Force * 10));
                                Invoke("JumpReset", .5f);
                            }
                        }
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    touchEnd = touch.position.y;
                    if (Mathf.Abs(touchStart - touchEnd) >= 10)
                    {
                        if (touchStart > touchEnd)
                        {
                            if (!IsJump && !isSlide)
                            {
                                isSlide = true;
                                anim.SetBool("Slide", true);
                                Invoke("SlideReset", 1);
                            }
                        }
                        else if (touchStart < touchEnd)
                        {
                            if (!IsJump && !isSlide)
                            {
                                CancelInvoke("JumpReset");
                                IsJump = true;
                                anim.SetBool("Jump", true);
                                Ninjaa.AddForce(new Vector2(0, Force * 10));
                                Invoke("JumpReset", .5f);
                            }
                        }
                    }
                }
            }
        }
    }
}
