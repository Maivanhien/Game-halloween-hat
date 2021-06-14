using UnityEngine;

public class Objectmovement : MonoBehaviour
{
    private float speech;
    void Start()
    {
        speech = 4.5f;
        if (gameObject.tag == "Supperlon") speech = 6.5f;
        if (gameObject.tag == "Tuchangia") speech = 4.15f;
        if (gameObject.tag == "Crowlua") speech = 7.5f;
    }
    void Update()
    {
        transform.Translate(new Vector3(0, -speech * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, -4.4f, 10), transform.position.z);
    }
    protected bool vectoequal(Vector3 vecto)
    {
        if (vecto.y == -4.4f)
            return true;
        else return false;
    }
}
