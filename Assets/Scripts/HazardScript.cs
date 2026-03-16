using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0,0);
        if (Player.transform.position.y < transform.position.y)
        {
            { 
                vel.y = -2;
            }
        }
        if (Player.transform.position.y > transform.position.y)
        {
            {
                vel.y = 2;
            }
        }
        if (Player.transform.position.x > transform.position.x)
        {
            {
                vel.x = 2;
            }
        }
        if (Player.transform.position.x < transform.position.x)
        {
            {
                vel.x = -2;
            }
        }
        RB.linearVelocity = vel;
        //every frame if above the player, move down at a speed of 2/second
        //if below the player, move up. if left, right. if right, left
    }
}
