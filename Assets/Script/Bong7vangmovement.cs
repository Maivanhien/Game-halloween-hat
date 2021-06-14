using UnityEngine;

public class Bong7vangmovement : Bongbongmovement
{
    private float speechs, movement;
    private float time;
    private bool rigth;
    void Start()
    {
        //Di chuyển nữa đường tròn
        time = 0f;
        speechs = 4.2f;
        movement = 7.6f;
        if (transform.position.x == -2.5f)
            rigth = true;
        if (transform.position.x == 2.5f)
            rigth = false;
    }

    void Update()
    {
        if (rigth == true)
        {
            transform.Translate(new Vector3(movement * Mathf.Cos(time * Mathf.PI) * Time.deltaTime, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            time += Time.deltaTime;
            time = time % 1;
        }
        else
        {
            transform.Translate(new Vector3(-movement * Mathf.Cos(time * Mathf.PI) * Time.deltaTime, -speechs * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            time += Time.deltaTime;
            time = time % 1;
        }
    }
}
