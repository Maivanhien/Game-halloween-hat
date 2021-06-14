using System.Collections;
using UnityEngine;

public class Bong4movement : Bongbongmovement
{
    private float speechs, movement;
    private int rand;
    private bool breakObject, right, left, continute;
    void Start()
    {
        //sau khoang thi gian thi tan ra khoi hinh
        continute = true;
        breakObject = false;
        speechs = 3.8f;
        movement = 4.3f;
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            right = false;
            left = true;
        }
        if (rand == 2)
        {
            right = true;
            left = false;
        }
        StartCoroutine(breakGameobject());
    }
    void Update()
    {
        if(breakObject==false)
        {
            transform.Translate(new Vector3(0, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10), transform.position.z);
        }
        else
        {
            if (continute == true)
            {
                StartCoroutine(objectrandom());
                continute = false;
            }
            if (right == true)
                transform.Translate(new Vector3(movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
            if (left == true)
                transform.Translate(new Vector3(-movement * Time.deltaTime, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10), transform.position.z);
            if (transform.position.x == 2.5f)
            {
                right = false;
                left = true;
            }
            if (transform.position.x == -2.5f)
            {
                right = true;
                left = false;
            }
        }
    }
    IEnumerator objectrandom()
    {
        yield return new WaitForSeconds(0.4f);
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            right = false;
            left = true;
        }
        if (rand == 2)
        {
            right = true;
            left = false;
        }
        continute = true;
    }
    IEnumerator breakGameobject()
    {
        yield return new WaitForSeconds(0.8f);
        breakObject = true;
    }
}
