using UnityEngine;

public class Bongxanhmovement : Bongbongmovement
{
    private float speechs, movement;
    private bool rigth, left, middle;
    void Start()
    {
        //di chuyen nhieu huong
        middle = false;
        speechs = 4.6f;
        movement = 5.5f;
        if(transform.position.x==0)
        {
            middle = true;
        }
        if(transform.position.x==2.5f|| transform.position.x == 0.1f)
        {
            rigth = true;
            left = false;
        }
        if (transform.position.x == -2.5f || transform.position.x == -0.1f)
        {
            rigth = false;
            left = true;
        }
    }

    void Update()
    {
        if(middle==false)
        {
            if (rigth == true)
            {
                transform.Translate(new Vector3(movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            }
            if (left == true)
            {
                transform.Translate(new Vector3(-movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            }
            if (transform.position.x == 2.5f)
            {
                rigth = false;
                left = true;
            }
            if (transform.position.x == -2.5f)
            {
                rigth = true;
                left = false;
            }
        }
        else
        {
            transform.Translate(new Vector3(0, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
        }
    }
}
