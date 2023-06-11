using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public AudioSource boom;
    public AudioSource start;
    public AudioSource end;
    public AudioSource blast;
    void InvokeBoom()
    {
        boom.Play();
    }
    void InvokeStart()
    {
        start.Play();
    }
    void InvokeEnd()
    {
        end.Play();
    }
    void InvokeBlast()
    {
        blast.Play();
    }
}
