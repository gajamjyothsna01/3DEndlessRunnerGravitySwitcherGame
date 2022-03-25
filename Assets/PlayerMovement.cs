using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerJumpforce;
    public float playerSpeed;
    Rigidbody rb;
    int score;
   
   
  //  bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Endless Player Movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * playerJumpforce);

            //Access the Gravity
            Physics.gravity *= -1;
        }
        score = Mathf.FloorToInt(transform.position.x);
        Debug.Log(score);
        if(score > 10)
        {
            //  rb.velocity = new Vector3(rb.position.x * playerSpeed, rb.position.y , rb.position.z);
            //Speed up the movement of the player
            playerSpeed = playerSpeed * 2;
        }


        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, rb.velocity.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleCollider>()!=null)
        {
            Destroy(this.gameObject);
        }
    }
}
