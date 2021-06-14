using UnityEngine;

public class Bongphanra : Bongbongmovement
{
    private float speechs, movement;
    private bool rigth, left, up;
    void Start()
    {
        rigth = false;
        left = false;
        up = false;
        speechs = 4.2f;
        if(this.gameObject.name=="Greencircle 1(Clone)")
        {
            left = true;
            speechs = 3.9f;
            movement = speechs * Mathf.Tan(2 * Mathf.PI * 60 / 360);
        }
        if (this.gameObject.name == "Greencircle(Clone)")
        {
            rigth = true;
            up = true;
            speechs = 4.6f;
            movement = speechs * Mathf.Tan(2 * Mathf.PI * 60 / 360);
        }
        if (this.gameObject.name == "Redcircle 1(Clone)")
        {
            rigth = true;
            movement = 0f;
        }
        if (this.gameObject.name == "Redcircle(Clone)")
        {
            up = true;
            rigth = true;
            movement = 0f;
            speechs = 5f;
        }
        if (this.gameObject.name == "Yellowcircle(Clone)")
        {
            rigth = true;
            speechs = 3.9f;
            movement = speechs * Mathf.Tan(2 * Mathf.PI * 60 / 360);
        }
        if (this.gameObject.name == "Yellowcircle 1(Clone)")
        {
            left = true;
            up = true;
            speechs = 4.6f;
            movement = speechs * Mathf.Tan(2 * Mathf.PI * 60 / 360);
        }
    }
    void Update()
    {
        if(up == true)
        {
            if(rigth==true)
            {
                transform.Translate(new Vector3(movement*Time.deltaTime, speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 4.65f), transform.position.z);
            }
            if(left==true)
            {
                transform.Translate(new Vector3(-movement * Time.deltaTime, speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 4.65f), transform.position.z);
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
            if (transform.position.y == 4.65f)
            {
                up = false;
            }
        }
        else
        {
            if (rigth == true)
            {
                transform.Translate(new Vector3(movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 4.65f), transform.position.z);
            }
            if (left == true)
            {
                transform.Translate(new Vector3(-movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 4.65f), transform.position.z);
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
