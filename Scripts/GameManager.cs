using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    
    [SerializeField]
   
    private bool _madeBasket = false;
    [SerializeField]
    public AudioSource _swish;
    private static bool _aroundtheWorld = false;
    private Scene currentScene;
    private string sceneName;
    private Ball _ball;

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
         currentScene = SceneManager.GetActiveScene();
         sceneName = currentScene.name;
        _ball = GameObject.Find("Ball").GetComponent<Ball>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        StartOver();

        if(_madeBasket == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _madeBasket = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _aroundtheWorld == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(3);
            AroundTheWorld();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _aroundtheWorld == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (sceneName == ("Options Menu") && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(3);
        }



    }
    public void StartOver()
    {
        if (sceneName == ("Level 20") && _madeBasket == true && Input.GetKeyDown(KeyCode.Space))
        {
            _aroundtheWorld = false;
            _ball.AroundIsFalse();
            SceneManager.LoadScene(0);
            
        }
        if (sceneName == ("Level 20") && _aroundtheWorld == false && Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(0);
        }
        
    }

    

    

    public void MadeBasket()
    {
        _madeBasket = true;
        GetComponent<AudioSource>().Play();
    }
    public void Death()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _aroundtheWorld = false;
            SceneManager.LoadScene(0);
        }
    }
    public void AroundTheWorld()
    {
        _aroundtheWorld = true;
    }


}
