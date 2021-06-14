using System.Collections;
using UnityEngine;

public class Bong5movement : Bongbongmovement
{
    private float speechs, movement;
    private bool start, stop;
    private int x;
    void Start()
    {
        //co, gian khoi hinh chu nhat
        speechs = 4f;
        movement = 4.5f;
        start = true;
        stop = false;
        if (transform.position.x == 0.96f) x = 1;
        if (transform.position.x == 0.316f) x = 2;
        if (transform.position.x == -0.329f) x = 3;
        if (transform.position.x == -0.959f) x = 4;
    }
    void Update()
    {
        if(start==true)
        {
            StartCoroutine(objectStart());
            start = false;
        }
        if (stop == true)
        {
            StartCoroutine(objectStop());
            stop = false;
        }
        transform.Translate(new Vector3(movement*Time.deltaTime, -speechs * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10), transform.position.z);
    }
    IEnumerator objectStart()
    {
        if (gameObject.tag == "BongBlue") speechs = 2;
        if (gameObject.tag == "BongGreen") speechs = 3;
        if (gameObject.tag == "BongRed") speechs = 4;
        if (gameObject.tag == "BongYellow") speechs = 5;
        if (x == 1) movement = 1.5f;
        if (x == 2) movement = 0.5f;
        if (x == 3) movement = -0.5f;
        if (x == 4) movement = -1.5f;
        yield return new WaitForSeconds(0.5f);
        stop = true;
    }
    IEnumerator objectStop()
    {
        if (gameObject.tag == "BongBlue") speechs = 5;
        if (gameObject.tag == "BongGreen") speechs = 4;
        if (gameObject.tag == "BongRed") speechs = 3;
        if (gameObject.tag == "BongYellow") speechs = 2;
        if (x == 1) movement = -1.5f;
        if (x == 2) movement = -0.5f;
        if (x == 3) movement = 0.5f;
        if (x == 4) movement = 1.5f;
        yield return new WaitForSeconds(0.5f);
        start = true;
    }
}
