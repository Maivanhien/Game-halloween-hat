using UnityEngine;

public class Destroydoi : MonoBehaviour
{
    [SerializeField] private GameObject doiCon,doiSpeech,doiaudio;
    int rand;
    void Start()
    {
        rand = Random.Range(1, 4);
    }
    void OnMouseDown()
    {
        if(rand==1)
        {
            Instantiate(doiSpeech, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (rand == 2)
        {
            Instantiate(doiaudio, transform.position, Quaternion.identity);
            Instantiate(doiCon, new Vector3(-2.2f, 5f, transform.position.z), Quaternion.identity);
            Instantiate(doiCon, new Vector3(0f, 5f, transform.position.z), Quaternion.identity);
            Instantiate(doiCon, new Vector3(2.2f, 5f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        if (rand == 3)
        {
            Instantiate(doiSpeech, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
