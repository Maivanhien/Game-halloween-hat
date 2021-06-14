using UnityEngine;

public class Doiconmovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    private float speech;
    void Start()
    {
        speech = 2.5f;
    }
    void Update()
    {
        transform.Translate(new Vector3(0, -speech * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
    }
    void LateUpdate()
    {
        if (this.transform.position.y == -4.4f)
        {
            Destroy(gameObject);
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
}
