using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField]
    private int _points = 0;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private static bool _aroundtheWorld = false;

    

    private Rigidbody2D _ball;
 
    private GameManager _gameManager;
    private Drag _drag;
    private Drag _smallDrag;
    
    private  UI_Manager _ui;
    [SerializeField]
    private AudioClip _ballBounce;




    // Start is called before the first frame update


    
    void Start()
    {
        transform.position = new Vector3(-5.7f, 4.41f, 0);
        
        _ball = GetComponent<Rigidbody2D>();
        _ball.gravityScale = 0;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = _ballBounce;

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _drag = GameObject.Find("Obstacle").GetComponent<Drag>();
        _ui = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _smallDrag = GameObject.Find("Small Obstacle").GetComponent<Drag>();
       









    }

    // Update is called once per frame
    void Update()
    {

        AroundTheWorld();

        if (_aroundtheWorld == true)
        {

            UIUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _ball.gravityScale == 0)
            
        {
            
            _ball.gravityScale = 1;
            _ball.constraints = RigidbodyConstraints2D.None;
            _drag.GravityOn();
            _smallDrag.GravityOn();
            
           
           
        }
        else if(Input.GetKeyDown(KeyCode.Space) && _ball.gravityScale == 1)
        {
            transform.position = new Vector3(-5.7f, 4.41f, 0);
            _ball.gravityScale = 0;
            _ball.constraints = RigidbodyConstraints2D.FreezeAll;
            _drag.GravityOff();
            _smallDrag.GravityOff();
           
           
           

        }

        






    }
    public void MadeBasket()
    {
        _points = _points + 1;
        
        _gameManager.MadeBasket();
        _ui.MadeBasket();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            GetComponent<AudioSource>().Play();
        }
        
        
    }

    public void AroundTheWorld()
    {
        if (Input.GetKeyDown(KeyCode.A) && _aroundtheWorld == false)
        {
            _aroundtheWorld = true;
           


        }

        if (Input.GetKeyDown(KeyCode.Space) && _ball.gravityScale == 1 && _aroundtheWorld ==true)
        {
            _lives = _lives - 1;
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && _ball.gravityScale == 1 && _aroundtheWorld == true && _points >= 1)
        {
            _lives = 3;
        }
        if (_lives < 1)
        {
            _ball.gravityScale = 2;
            transform.position = new Vector3(-5.7f, 4.41f, 0);
            _ball.constraints = RigidbodyConstraints2D.FreezeAll;
           
            _ui.TryAgain();
           
           
          _gameManager.Death();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _aroundtheWorld = false;
        }
    }

    public void UIUpdate()
    {
        _ui.LivesRemaining(_lives);
    }
    public void AroundIsTrue()
    {
        _aroundtheWorld = true;
    }
    public void AroundIsFalse()
    {
        _aroundtheWorld = false;
    }
   
}
