using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private Text _pressSpace;
    [SerializeField]
    private Text _pressSpace1;
    [SerializeField]
    private Text _pressSpace2;



    // Start is called before the first frame update
    void Start()
    {
        _pressSpace.text = ("");
        _pressSpace1.text = ("");
        _pressSpace2.text = ("");
        StartCoroutine(StartSpace());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartLevel());
           


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
   IEnumerator StartLevel()
    {
        
        
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }

    IEnumerator StartSpace()
    {
        yield return new WaitForSeconds(2);
        _pressSpace.text = ("Press SPACE");
        _pressSpace1.text = ("Press SPACE");
        _pressSpace2.text = ("Press SPACE");
    }   
       
}
