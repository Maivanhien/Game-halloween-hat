using UnityEngine;

public class BongBluemovement : Bongbongmovement
{
    private float speechs, movement;
    private float time;
    private bool c;
    void Start()
    {
        //Di chuyen cac qua bong theo hinh tron va dich xuong
        c = false;
        speechs = 6.7f;
        movement = 7.2f;
        time = 0f;
        if (transform.position.x == -2.3f) c = true;
    }
    void Update()
    {
        if(c == true)
            transform.Translate(new Vector3(movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speechs * Mathf.Cos(time * Mathf.PI) * Time.deltaTime - 2.2f* Time.deltaTime, 0));
        else
            transform.Translate(new Vector3(-movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speechs * Mathf.Cos(time * Mathf.PI) * Time.deltaTime - 2.2f * Time.deltaTime, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
        time += Time.deltaTime;
    }
}
