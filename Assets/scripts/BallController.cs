using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D BallRb;
    bool ballWasUnpaused = false;
    bool setInitSpeed;
    [SerializeField] float speedUp;
    UnityEngine.Vector2 ballVelocity;
    float xSpeed;
    float ySpeed;

    private void Start()
    {
        //executed once at the start to initialize our rigid body
        BallRb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (GameController.instance.inPlay == true && GameController.instance.inPause == false)
        {
            if (!setInitSpeed)
            {
                setInitSpeed = true;

                //choose the initial speed of the ball 
                xSpeed = Random.Range(1f, 2f) * ((Random.Range(0, 2) * 2) - 1);
                ySpeed = Random.Range(1f, 2f) * ((Random.Range(0, 2) * 2) - 1);
            }
            MoveBall();
        }
       
        if (GameController.instance.inPause == true && GameController.instance.inPlay == true)
        {
            //PauseBall
            PauseBall();
            ballWasUnpaused = true;
        }

        if (GameController.instance.inPause == false && GameController.instance.inPlay == true && ballWasUnpaused == true)
        {
            //PauseBall
            UnpauseBall();
            ballWasUnpaused = false;
        }

    }

    void MoveBall()
    {
        print("lifes remaining : " + GameController.instance.lifes_remaining + "inplay : " + GameController.instance.inPlay);

        BallRb.velocity = new Vector2(xSpeed, ySpeed);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.transform.tag == "WallSide")
        {
            //travels in the opposite direction(-) and keeps the same speed (1)
            xSpeed = xSpeed * -1;
        }

        if (other.transform.tag == "WallUp")
        {
            ySpeed = ySpeed * -1;
        }

        if (other.transform.tag == "Paddle")
        {
            ySpeed = ySpeed * -1;

            //so that the speed of the ball increases everytime it hits the paddle 
            if (xSpeed > 0)
            {
                xSpeed += speedUp;
            }
            else
            {
                xSpeed -= speedUp;
            }

            if (ySpeed > 0)
            {
                ySpeed += speedUp;
            }
            else
            {
                ySpeed -= speedUp;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Goal") //if the ball falls down
        {
            //the player looses a life
            GameController.instance.lifes_remaining--; 

            //stop the ball
            setInitSpeed = false; // to initialise the ball's position 
            BallRb.velocity = Vector2.zero;
            this.transform.position = Vector2.zero;

        }
    }

    public void PauseBall()
    {
        //stop the ball and save it's velocity
        ballVelocity = BallRb.velocity;
        BallRb.velocity = Vector2.zero;

        print("the ball is paused");
    }

    public void UnpauseBall()
    {
        BallRb.velocity = ballVelocity;

        print("the ball is unpaused");
    }

}
