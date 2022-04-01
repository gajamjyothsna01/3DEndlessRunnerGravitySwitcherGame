using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float playerJumpforce;
    public float playerSpeed;
    Rigidbody rb;
    int score;
    public int speedToIncrease;
    int increaseTheSpeedAfterSomeDistance = 10;
    public Text scoreText, textScore;
    public GameObject youWinImage;
   
   
  //  bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        PlayerPrefs.SetString("Name", "Happy");
        Debug.Log(PlayerPrefs.GetString("Name"));

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
        score = Mathf.FloorToInt(transform.position.x); //Getting the larger int value from float through the player position.
        //Debug.Log(score);
       
        scoreText.text = score.ToString();
        Debug.Log(score);
        Debug.Log(PlayerPrefs.GetInt("Score"));
        
        PlayerPrefs.SetInt("Score", score);   //Saving the dATA.
        
        //Increase the PlayerSpeed after some Distance\
        if(score > 100)
        {
            youWinImage.SetActive(true);
        }
        if(score == speedToIncrease)
        {
            playerSpeed = playerSpeed + 0.5f;
            speedToIncrease = speedToIncrease + increaseTheSpeedAfterSomeDistance;
        }
        
        /*
        if(score > 10)
        {
            //  rb.velocity = new Vector3(rb.position.x * playerSpeed, rb.position.y , rb.position.z);
            //Speed up the movement of the player
            playerSpeed = playerSpeed * 2;
        }*/


        
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
