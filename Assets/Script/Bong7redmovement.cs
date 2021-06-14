using System.Collections;
using UnityEngine;

public class Bong7redmovement : Bongbongmovement
{
    private float speechs, rotation;
    private bool rigth, left, down, rotate;
    void Start()
    {
        //Di chuyen hinh bac 3
        speechs = 6.75f;
        if(this.transform.position.x==-2.75f)
        {
            rigth = true;
            left = false;
            rotation = 7f;
        }
        if(this.transform.position.x==2.75f)
        {
            rigth = false;
            left = true;
            rotation = -7f;
        }
        rotate = false;
        down = true;
        StartCoroutine(clonerotation());
    }
    void Update()
    {
        if (rigth == true)
        {
            if(rotate==false)
            {
                this.transform.Translate(0f, -speechs * Time.deltaTime,0f);
                this.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
            }
            else
            {
                if(down==true)
                {
                    rotation += 350 * Time.deltaTime;
                    rotation = Mathf.Clamp(rotation, 7f, 165f);
                }
                else
                {
                    rotation -= 350 * Time.deltaTime;
                    rotation = Mathf.Clamp(rotation, 7f, 165f);
                }
                if (rotation == 165) down = false;
                this.transform.Translate(0f, -speechs * Time.deltaTime, 0f);
                this.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
                this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            }
        }
        if (left == true)
        {
            if (rotate == false)
            {
                this.transform.Translate(0f, -speechs * Time.deltaTime, 0f);
                this.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
            }
            else
            {
                if (down == true)
                {
                    rotation -= 350 * Time.deltaTime;
                    rotation = Mathf.Clamp(rotation, -165f, -7f);
                }
                else
                {
                    rotation += 350 * Time.deltaTime;
                    rotation = Mathf.Clamp(rotation, -165f, -7f);
                }
                if (rotation == -165) down = false;
                this.transform.Translate(0f, -speechs * Time.deltaTime, 0f);
                this.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
                this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            }
        }
    }
    IEnumerator clonerotation()
    {
        yield return new WaitForSeconds(0.665f);
        rotate = true;
    }
}
