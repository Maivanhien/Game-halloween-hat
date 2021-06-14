using System.Collections;
using UnityEngine;

public class BongMaybay : Bongbongmovement
{
    private float speechs;
    private int i;
    void Start()
    {
        i = 0;
        speechs = 2.5f;
        if (transform.position.y == 6.506f)
            i = 1;
        StartCoroutine(objectBreak());
    }
    void Update()
    {
        transform.Translate(new Vector3(0, -speechs * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10), transform.position.z);
    }
    IEnumerator objectBreak()
    {
        if (i == 1) yield return new WaitForSeconds(0.5f);
        else yield return new WaitForSeconds(8.3f);
        speechs = 5;
    }
}
