using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    
    private bool isClicked = false;
    [SerializeField]
    private bool _gravity = false;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(4, 3.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
       if(isClicked == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

        }

       if(_gravity == true)
        {
            isClicked = false;
        }
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isClicked = true;

        }
    }

    private void OnMouseUp()
    {
        isClicked = false;
    }

    public void GravityOn()
    {
        _gravity = true;
    }
    public void GravityOff()
    {
        _gravity = false;
    }
    

}
