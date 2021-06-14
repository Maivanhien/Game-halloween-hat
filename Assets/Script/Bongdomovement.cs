using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bongdomovement : Bongbongmovement
{
    private float movement, current;
    private bool phai, trai;
    void Start()
    {
        //Di chuyen ngang xuyen khong
        phai = false;
        trai = false;
        movement = 8.8f;
        if (transform.position.x == -2.5f)
        {
            phai = true;
            current = 4.65f;
        }
        if (transform.position.x == 2.5f)
        {
            trai = true;
            current = 4.65f;
        }
    }

    void Update()
    {
        if (phai == true)
        {
            transform.Translate(new Vector3(movement * Time.deltaTime, 0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            if (transform.position.x == 2.5f)
            {
                current -= 2f;
                transform.position = new Vector3(-2.5f, current, transform.position.z);
            }
        }
        if (trai == true)
        {
            transform.Translate(new Vector3(-movement * Time.deltaTime, 0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            if (transform.position.x == -2.5f)
            {
                current -= 2f;
                transform.position = new Vector3(2.5f, current, transform.position.z);
            }
        }
    }
}
