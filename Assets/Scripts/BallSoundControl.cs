using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundControl : MonoBehaviour
{
    private AudioSource ballkick;
    void Start()
    {
        ballkick = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   private void OnCollisionEnter2D(Collision2D other) 
   {
       ballkick.Play();
   }
}
