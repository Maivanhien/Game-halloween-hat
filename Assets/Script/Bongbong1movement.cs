using UnityEngine;

public class Bongbong1movement : Bongbongmovement
{
    private float speechs, movement, current;
    private bool rigth, left, phai, trai;
    void Start()
    {
        //Di chuyen cheo va cheo xuyen khong
        phai = false;
        trai = false;
        speechs = 4.23f;
        movement = 9f;
        rigth = true;
        left = false;
        if(transform.position.x == -2.45f)
        {
            phai = true;
            speechs = 6f;
            movement = 6.5f;
            current = 5.33f;
        }
        if (transform.position.x == 2.45f)
        {
            trai = true;
            speechs = 6f;
            movement = 6.5f;
            current = 5.33f;
        }
    }

    void Update()
    {
        if(phai == true)
        {
            transform.Translate(new Vector3(movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            if(transform.position.x==2.5f)
            {
                current -= 2.85f;
                transform.position = new Vector3(-2.5f, current, transform.position.z);
            }
        }
        else if(trai == true)
        {
            transform.Translate(new Vector3(-movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            if (transform.position.x == -2.5f)
            {
                current -= 2.85f;
                transform.position = new Vector3(2.5f, current, transform.position.z);
            }
        }
        else
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
    }
}
