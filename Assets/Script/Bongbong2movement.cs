using UnityEngine;

public class Bongbong2movement : Bongbongmovement
{
    private float speechs, movement;
    private float time;
    private bool rigth, phai, trai, rigth1;
    void Start()
    {
        //Neu vi tri qua bong o hai phia thi di chuyen theo hinh sin
        //neu vi tri qua bong o giua thi di chuyen theo hinh parapol y = x^2
        rigth1 = false;
        time = 0f;
        speechs = 4f;
        movement = 8f;
        if (transform.position.x == -2.5f)
            rigth = true;
        if (transform.position.x == 2.5f)
            rigth = false;
        if(transform.position.x==0.1f)
        {
            time = 0.65f;
            speechs = 3.5f;
            movement = 3f;
            rigth1 = true;
            phai = true;
            trai = false;
        }
        if (transform.position.x == -0.1f)
        {
            time = 0.65f;
            speechs = 3.5f;
            movement = 3f;
            rigth1 = true;
            phai = false;
            trai = true;
        }
    }

    void Update()
    {
        if(rigth1==false)
        {
            if (rigth == true)
            {
                transform.Translate(new Vector3(movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
                time += Time.deltaTime;
            }
            else
            {
                transform.Translate(new Vector3(-movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
                time += Time.deltaTime;
            }
        }
        else
        {
            if(phai==true)
            {
                transform.Translate(new Vector3(movement * time * time * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
                time += Time.deltaTime;
                time = Mathf.Clamp(time, 0f, 1.85f);
            }
            if (trai == true)
            {
                transform.Translate(new Vector3(-movement * time * time * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
                time += Time.deltaTime;
                time = Mathf.Clamp(time, 0f, 1.85f);
            }
            if(transform.position.x==2.5f)
            {
                trai = true;
                phai = false;
            }
            if (transform.position.x == -2.5f)
            {
                trai = false;
                phai = true;
            }
        }
    }
}
