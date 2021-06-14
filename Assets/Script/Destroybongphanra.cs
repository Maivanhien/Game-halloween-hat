using UnityEngine;

public class Destroybongphanra : MonoBehaviour
{
    public GameObject redCircle, redCircle1, yellowCircle, yellowCircle1, greenCircle, greenCircle1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linear")
        {
            Objectpooler.Instance.SpawnFromPool("BongphanraExploded", transform.position, Quaternion.identity);
            Instantiate(redCircle, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
            Instantiate(redCircle1, new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z), Quaternion.identity);
            Instantiate(yellowCircle, new Vector3(transform.position.x + 0.671f, transform.position.y - 0.385f, transform.position.z), Quaternion.identity);
            Instantiate(yellowCircle1, new Vector3(transform.position.x - 0.667f, transform.position.y + 0.338f, transform.position.z), Quaternion.identity);
            Instantiate(greenCircle, new Vector3(transform.position.x + 0.667f, transform.position.y + 0.338f, transform.position.z), Quaternion.identity);
            Instantiate(greenCircle1, new Vector3(transform.position.x - 0.671f, transform.position.y - 0.385f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
