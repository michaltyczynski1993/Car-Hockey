using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Goal : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider2D) 
    {
      if(collider2D.tag != "Player")
      {
        GameControl.instance.P1Scored();
      }
            
    }
}
