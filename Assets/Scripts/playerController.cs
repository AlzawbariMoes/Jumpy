using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class playerController : MonoBehaviour {

    public  float Speed;
    public float jumpForce;
    private int extraJump;
    public int extraJumpValue;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool IsGrounded;
    public Transform groundCheck;
    public float checkRadious;
    public LayerMask WhatIsGrounded;
    public LayerMask WhatIsLadder;
    public float distance;
    private bool climbing;
    private float inputVertical;
    public GameObject Coin;
    public GameObject GameOver;
    public GameObject BossSprite;
    public AudioClip LosingSoundtrack;
    public AudioClip CoinSound;
    public AudioClip JumpSoundtrack;
    public AudioClip LoseSoundtrack;
 
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UpButton;
    public GameObject GameSoundtrackHolder;

 
    float DirX;
    float DirY;
    float horizontal;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;

     }
    void Update()
    {
         AudioSource audio = GetComponent<AudioSource>();
         DirX = CrossPlatformInputManager.GetAxis("Horizontal");
         float horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            audio.PlayOneShot(JumpSoundtrack);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (IsGrounded == true && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
            audio.PlayOneShot(JumpSoundtrack);
        }
      
    }
    //To manage all the physics related aspects of the game
    private void FixedUpdate()
    {
 
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, WhatIsGrounded);

        //Move our player with Keyboard control
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        //Move our player with phone control
        rb.velocity = new Vector2(DirX * Speed, rb.velocity.y);
 
        

        //Flip our player on keyboard control
        if (facingRight == false  && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true  && moveInput < 0)
        {
            Flip();
        }
        //Flip our player on phone control
        if (facingRight == true && DirX == -1)
        {
            Flip();
        }
        else if (facingRight == false && DirX == 1)
        {
            Flip();
        }

        // Ladder system
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up,distance,WhatIsLadder);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                climbing = true;
            }
            else if(CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                climbing = true;
             }
        }
        else
        {
            climbing = false;
        }
        
        if(climbing == true)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * Speed);

            rb.velocity = Vector2.up * jumpForce;
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    
     }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();

        // fall
        if (collision.gameObject.tag == "Fail")
        { 
            Debug.Log("GAMEOVER!!");
            GameOver.SetActive(true);
            //audio.PlayOneShot(LosingSoundtrack);
            //audio.PlayOneShot(LoseSoundtrack);
            Time.timeScale = 0;

            LeftButton.SetActive(false);
            RightButton.SetActive(false);
            UpButton.SetActive(false);
            GameSoundtrackHolder.SetActive(false);
        }
        // pumbkin enemy
        if (collision.gameObject.tag == "PumbkinEnemy")
        {
            Debug.Log("GAMEOVER!!");
            GameOver.SetActive(true);
            //audio.PlayOneShot(LosingSoundtrack);
           // audio.PlayOneShot(LoseSoundtrack);
            Time.timeScale = 0;

            LeftButton.SetActive(false); 
            RightButton.SetActive(false);
            UpButton.SetActive(false);
            GameSoundtrackHolder.SetActive(false);
        }
        //make boss sprite appears
        if (collision.gameObject.tag == "Boss Sprite")
        {
            BossSprite.SetActive(true);
            StartCoroutine(PumbkinBossSprite());
        }

        if (collision.gameObject.tag == "Coin")
        {
            audio.PlayOneShot(CoinSound);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //AudioSource audio = GetComponent<AudioSource>();

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("GAMEOVER!!");
            GameOver.SetActive(true);
            //audio.PlayOneShot(LosingSoundtrack);
           // audio.PlayOneShot(LoseSoundtrack);
            Time.timeScale = 0;

            LeftButton.SetActive(false);
            RightButton.SetActive(false);
            UpButton.SetActive(false);
            GameSoundtrackHolder.SetActive(false);
        }

    }
        IEnumerator PumbkinBossSprite()
    {
        yield return new WaitForSeconds(3);
        BossSprite.SetActive(false);
    }

  
 }
