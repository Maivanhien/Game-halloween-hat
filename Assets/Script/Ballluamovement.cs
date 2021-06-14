using UnityEngine;

public class Ballluamovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    private float speech, movement;
    private float time;
    private bool c, midle, right, left;
    private int rand;
    void Start()
    {
        //Di chuyen cac qua bong theo hinh tron va dich xuong, di chuyen cheo
        midle = false;
        right = false;
        left = false;
        c = false;
        speech = 7f;
        movement = 7f;
        time = 0f;
        if(transform.position.x == 0f)
        {
            midle = true;
            speech = 5.2f;
            movement = 4.5f;
            rand = Random.Range(1, 3);
            if (rand == 1) right = true;
            else left = true;
        }
        if (transform.position.x == -2.3f) c = true;
    }
    void Update()
    {
        if(midle == true)
        {
            if (right == true)
                transform.Translate(new Vector3(movement*Time.deltaTime,-speech*Time.deltaTime,0));
            if(left == true)
                transform.Translate(new Vector3(-movement * Time.deltaTime, -speech * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.4f, 2.4f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            if (transform.position.x == 2.4f)
            {
                right = false;
                left = true;
                movement = 8.5f;
            }
            if (transform.position.x == -2.4f)
            {
                right = true;
                left = false;
                movement = 8.5f;
            }
        }
        else
        {
            if (c == true)
                transform.Translate(new Vector3(movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speech * Mathf.Cos(time * Mathf.PI) * Time.deltaTime - 2.5f * Time.deltaTime, 0));
            else
                transform.Translate(new Vector3(-movement * Mathf.Sin(time * Mathf.PI) * Time.deltaTime, -speech * Mathf.Cos(time * Mathf.PI) * Time.deltaTime - 2.5f * Time.deltaTime, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.4f, 2.4f), Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
            time += Time.deltaTime;
        }
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
