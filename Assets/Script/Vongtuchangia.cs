using UnityEngine;

public class Vongtuchangia : MonoBehaviour
{
    private float speech;
    private float rotation;
    void Start()
    {
        speech = 0.5f;
        rotation = 0;
    }

    void Update()
    {
        rotation += 135 * Time.deltaTime;
        rotation = rotation % 360;
        transform.localEulerAngles = new Vector3(0f, 0f, rotation);
        transform.Translate(-speech * Time.deltaTime * Mathf.Sin(2 * Mathf.PI * rotation / 360), -speech * Time.deltaTime * Mathf.Cos(2 * Mathf.PI * rotation / 360), 0f);
    }
    void LateUpdate()
    {
        if (this.transform.childCount == 1)
            Destroy(gameObject);
    }
}
