using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float TapForce = 200;
    private Rigidbody thisRigidbody = null;

    

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisRigidbody.AddForce(Vector3.up * TapForce);
            thisAnimation.Play();
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            GameManager.thisManager.GameOver();
        }
    }
}
