using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float maxSpeed;
     public float acceleration;
     public float steering;
 
     private Rigidbody2D rb;
     private float currentSpeed;
     private bool canMove = true;
     public AudioSource sound;
    
     private void Start()
     {
         this.rb = GetComponent<Rigidbody2D>();
         this.sound = GetComponent<AudioSource>();
     }
     private void Update() 
     {
         if (GameControl.instance.isGameOver == true)
         {
             canMove = false;
         }
         sound.pitch = Mathf.Clamp(rb.velocity.magnitude/acceleration, currentSpeed, maxSpeed);
    }
 
     private void FixedUpdate()
     {
        if (canMove == true){
         // Get input
         float h = -Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");
                 
         // Calculate speed from input and acceleration (transform.up is forward)
         Vector2 speed = transform.up * (v * acceleration);
         rb.AddForce(speed);
 
         // Create car rotation
         float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
         if (direction >= -2.0f)
         {
             rb.rotation += h * steering * (rb.velocity.magnitude / maxSpeed);
         }
         else
         {
             rb.rotation -= h * steering * (rb.velocity.magnitude / maxSpeed);
         }
 
         // Change velocity based on rotation
         float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
         Vector2 relativeForce = Vector2.right * driftForce;
         Debug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.green);
         rb.AddForce(rb.GetRelativeVector(relativeForce));
 
         // Force max speed limit
         if (rb.velocity.magnitude > maxSpeed)
         {
             rb.velocity = rb.velocity.normalized * maxSpeed;
         }
         currentSpeed = rb.velocity.magnitude;
        }
     }
}
