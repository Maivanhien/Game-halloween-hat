using UnityEngine;

public class Bongvangmovement : Bongbongmovement
{
    private float speechs;
    void Start()
    {
        //Nhung duong vet chem
        speechs = 4.2f;
    }
    void Update()
    {
        transform.Translate(new Vector3(0, -speechs * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 15f), transform.position.z);
    }
}
