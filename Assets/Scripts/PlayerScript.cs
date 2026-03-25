using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them
    public SpriteRenderer SR;
    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;

    //TextMeshPro is a component that draws text on the screen.
    //Score and Health go here
    public TextMeshPro ScoreText;
    public TextMeshPro HealthText;
    
    //This will control how fast the player moves, and its jump height
    public float Speed = 5;
    public float JumpPower = 6;
    
    //This is how many points we currently have
    public int Score = 0;

    //Health
    public int Health = 4;

    //Start automatically gets triggered once when the objects turns on/the game starts

    //making the choin
    public CoinScript Coinprefab;
    void Start()
    {
        //During setup we call UpdateScore to make sure our score text looks correct
        UpdateScore();
    }
    
    //Update is a lot like Start, but it automatically gets triggered once per frame
    //Most of an object's code will be called from Update--it controls things that happen in real time
    
    
    
    
    
    void Update()
   
        
    {
        //health
        HealthText.text = "Health:" + Health;

        //The code below controls the character's movement
        //first code determines movement and falling speed
        Vector2 vel = new Vector2(0,RB.linearVelocity.y);

        //sprint mechanic
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            //if i hold down shift, sprint
            Speed = 7;
        }
        else
        {
            Speed = 5;

        }
        //If player falls from bottom, lands on top
        if (transform.position.y < -5.5)
        {
            //Remember Vector3 Shuffle
            transform.position = new Vector3(0, 4, 0);
            transform.position += new Vector3(0, 4.4f, 0);
            Vector3 pos = transform.position;
            pos.y = 4;
            transform.position = pos;
        }
      

            //Then we use if statement to figure out what that variable should look like

            //If I hold the right arrow key, the player should move right. . .
            if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        //If I press the up arrow key, the player should jump. . .
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vel.y = JumpPower;
        }
    
        
        //Finally, I take that variable and I feed it to the component in charge of movement
        RB.linearVelocity = vel;
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        //If it does...
        if (other.gameObject.CompareTag("Hazard"))
        {
            //takes away health
            Health--;
            HealthText.text = "Health:" + Health;
            if (Health <= 0)
            { //Run your 'you lose' function!
                Die();
            }
            
        }
        if (Health <= 1)
        { 
            //Change to red
         SR.color= Color.red;

        }

        
        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        //If it does, run the code block belows
        if (coin != null)
        {
            //tells the coin that they've bumped, so it can teleport
            coin.GetBumped();
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-7, 7f);
            pos.y = Random.Range(-4, 4f);
            coin.transform.position = pos;
            //Make your score variable go up by one. . .
            Score++;
            if(Score >= 10)
            { 
                Win();
            }
            //And then update the game's score text
            UpdateScore();
        }
    }

    //This function updates the game's score text to show how many points you have
    //Even if your 'score' variable goes up, if you don't update the text the player doesn't know
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void Win()
    {
        SceneManager.LoadScene("You Win");
    }
}
