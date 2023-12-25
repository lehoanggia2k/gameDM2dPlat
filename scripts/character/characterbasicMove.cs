using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterbasicMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpHight;
    private Animator player;
    //vacham
    int point = 0;
    public Text Score;
    int jumpsRemaining = 2; // set the initial number of jumps
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    bool isOnGround;
    void Start()
    {
        player = GetComponent<Animator>();
        Time.timeScale = 1;
        //diemso
        Score = GameObject.Find("Score").GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "money")
        {
            point++;
            Destroy(collision.gameObject);
            Score.text = "Score : " + point.ToString();
        }
        else if (collision.gameObject.tag == "trophy")
        {
            Application.LoadLevel("MainMenu");
        }

        // reset jumps when character touches ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            jumpsRemaining = 2;
            isOnGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (isOnGround)
            {
                player.SetBool("isIdle", false);
                player.SetBool("isRunning", true);
            }
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (isOnGround)
            {
                player.SetBool("isIdle", false);
                player.SetBool("isRunning", true);
            }
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        else if (isOnGround) 
        {
            player.SetBool("isIdle", true);
            player.SetBool("isRunning", false);
            player.SetBool("isJump", false);
        }
        else
        {
            player.SetBool("isIdle", false);
            player.SetBool("isRunning", false);
            player.SetBool("isJump", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
        {
            isOnGround = false;
            player.SetBool("isIdle", false);
            player.SetBool("isRunning", false);
            player.SetBool("isJump", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpHight);
            jumpsRemaining--; // decrement jumps remaining
        }

        
        if (gameObject.transform.position.y < -20)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
