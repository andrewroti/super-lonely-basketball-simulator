using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _teamworkGray;
    [SerializeField]
    private Text _teamworkOther;
    [SerializeField]
    private Text _teamworkWhite;
    [SerializeField]
    private Text _tryAgain1;
    [SerializeField]
    private Text _tryAgain2;
    [SerializeField]
    private Text _tryAgain3;
    [SerializeField]
    private  Text _livesRemaining;
    [SerializeField]
    private Text _livesRemaining1;
    [SerializeField]
    private Text _livesRemaining2;
   
    

    public bool _madeBasket = false;
    public bool _tryAgain = false;
    [SerializeField]
    private static bool _aroundtheWorld = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
       
        _teamworkGray.text = ("");
        _teamworkOther.text = ("");
        _teamworkWhite.text = ("");

        _tryAgain1.text = ("");
        _tryAgain2.text = ("");
        _tryAgain3.text = ("");

        _livesRemaining.text = ("");
        _livesRemaining1.text = ("");
        _livesRemaining2.text = ("");


}

    // Update is called once per frame
    void Update()
    {

        
        
        
        
        if(_madeBasket == true)
        {
            _teamworkGray.text = ("Teamwork!");
            _teamworkOther.text = ("Teamwork!");
            _teamworkWhite.text = ("Teamwork!");
            

        }
        if(_tryAgain == true)
        {
            _tryAgain1.text = ("Ope! Try again...?");
            _tryAgain2.text = ("Ope! Try again...?");
            _tryAgain3.text = ("Ope! Try again...?");
            
        }

        
       


    }

    public void MadeBasket()
    {
        _madeBasket = true;
    }
    public void TryAgain()
    {
        _tryAgain = true;
       
    }
    public void LivesRemaining(int _lives)
    {

        
        _livesRemaining.text = ("" + _lives);
        _livesRemaining1.text = ("" + _lives);
        _livesRemaining2.text = ("" + _lives);
        
        if(_lives == 0)
        {
           
            
            
            _livesRemaining.text = ("Press R to Restart");
            _livesRemaining1.text = ("Press R to Restart");
            _livesRemaining2.text = ("Press R to Restart");
            _livesRemaining.fontSize = 20;
            _livesRemaining1.fontSize = 20;
            _livesRemaining2.fontSize = 20;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _aroundtheWorld = false;
        }
        
    }
}
