using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaButtons : MonoBehaviour
{
    public Ninja ButtonReferencer;
    public void ThrowKunai()
    {
        ButtonReferencer.TKunai();
    }
    public void ThrowStar()
    {
        ButtonReferencer.TStar();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
