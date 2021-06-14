using System.Collections;
using UnityEngine;

public class Circlerotationmovement : MonoBehaviour
{
    private float speech;
    private float rotation;
    private bool egdeRotation1, rigth, isBomerang, isRotation;
    void Start()
    {
        rigth = false;
        egdeRotation1 = false;
        isBomerang = false;
        isRotation = false;
        speech = 4.35f;
        rotation = 0;
        if(this.gameObject.tag == "Egderotation1")
        {
            egdeRotation1 = true;
            if (this.transform.position.x == 2.5f)
                rigth = true;
        }
        if(this.gameObject.tag == "Bomerang")
        {
            speech = 5f;
            isBomerang = true;
            StartCoroutine(cloneobjectrotation());
        }
    }
    
    void Update()
    {
        if(isBomerang == true)
        {
            if(isRotation == false)
            {
                rotation -= 410 * Time.deltaTime;
                rotation = rotation % 360;
                transform.localEulerAngles = new Vector3(0f, 0f, rotation);
                transform.Translate(-speech * Time.deltaTime * Mathf.Sin(2 * Mathf.PI * rotation / 360) - speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360) * Mathf.Tan(Mathf.PI / 4), -speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360), 0f);
            }
            else
            {
                rotation -= 410 * Time.deltaTime;
                rotation = rotation % 360;
                transform.localEulerAngles = new Vector3(0f, 0f, rotation);
                transform.Translate(-speech * Time.deltaTime * Mathf.Sin(2 * Mathf.PI * rotation / 360) + speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360) * Mathf.Tan(Mathf.PI / 4), -speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360), 0f);
            }
        }
        else if(egdeRotation1 == true)
        {
            if(rigth == true)
            {
                rotation += 260 * Time.deltaTime;
                rotation = Mathf.Clamp(rotation, 0f, 180f);
                if (rotation == 180f)
                {
                    rotation = 0f;
                    this.transform.Translate(0f, 1.97f, 0f);
                }
            }
            else
            {
                rotation -= 260 * Time.deltaTime;
                rotation = Mathf.Clamp(rotation, -180f, 0f);
                if (rotation == -180f)
                {
                    rotation = 0f;
                    this.transform.Translate(0f, 1.97f, 0f);
                }
            }
            transform.localEulerAngles = new Vector3(0f, 0f, rotation);
        }
        else
        {
            if (this.gameObject.tag == "Egderotation")
            {
                rotation += 280 * Time.deltaTime;
                speech = 4.2f;
            }
            else if (this.gameObject.tag == "Circlerotation1")
            {
                rotation += 220 * Time.deltaTime;
                speech = 4.1f;
            }
            else if (this.gameObject.tag == "Circlerotation2")
            {
                rotation -= 240 * Time.deltaTime;
                speech = 4.1f;
            }
            else
                rotation -= 200 * Time.deltaTime;
            rotation = rotation % 360;
            transform.localEulerAngles = new Vector3(0f, 0f, rotation);
            transform.Translate(-speech * Time.deltaTime * Mathf.Sin(2 * Mathf.PI * rotation / 360), -speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360), 0f);
        }
    }
    void LateUpdate()
    {
        if (this.transform.childCount == 0)
            Destroy(gameObject);
    }
    IEnumerator cloneobjectrotation()
    {
        yield return new WaitForSeconds(1.35f);
        isRotation = true;
    }
}
