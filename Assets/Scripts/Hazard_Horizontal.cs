using UnityEngine;

public class WrapGame : MonoBehaviour
{
    public Transform T;
    //Rigidbody is for movement!
    public Rigidbody2D RB;
    //this will set our movement speed
    public float Speed = 1;
    //bool = true or false statement
    public bool Move = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    //If move, character moves to the right automatically 
    {
        if (Move)
        {
            transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
        }
        //If i move to the right end of the screen, i need to pop up on the start of the left side of the screen
        if (transform.position.x > 10)
        {
            //Remember Vector3 Shuffle
            transform.position = new Vector3(-10, 0, 0);
            transform.position += new Vector3(-10.1f, 0, 0);
            Vector3 pos = transform.position;
            pos.x = -10;
            transform.position = pos;
        }
        //if i move to the left end of the screen, i pop up on the right side of the screen
        if (transform.position.x < -10)
        {
            //Remember Vector3 Shuffle
            transform.position = new Vector3(10, 0, 0);
            transform.position += new Vector3(10.1f, 0, 0);
            Vector3 pos = transform.position;
            pos.x = 10;
            transform.position = pos;
        }
    }
}