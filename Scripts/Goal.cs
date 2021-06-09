using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    private Ball _ball;

    // Start is called before the first frame update

    public AudioSource _rimSounds;
    void Start()
    {
        _ball = GameObject.Find("Ball").GetComponent<Ball>();
        _rimSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            _ball.MadeBasket();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
