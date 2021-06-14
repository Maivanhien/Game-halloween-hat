using UnityEngine;

public class Ballspeechmovement : MonoBehaviour, Interfaceball
{
    [SerializeField] private GameObject dieAudio;
    private float speech, movement;
    private bool right, left,up;
    public void Ballspawnfrompool()
    {
        if(transform.position.x>=0)
        {
            right = true;
            left = false;
        }
        else
        {
            right = false;
            left = true;
        }
        up = true;
    }
    void Start()
    {
        movement = 4.5f;
        speech = 9.2f;
    }
    void Update()
    {
        if(up == true)
        {
            if (right == true)
                transform.Translate(new Vector3(movement * Time.deltaTime, speech * Time.deltaTime, 0));
            if (left == true)
                transform.Translate(new Vector3(-movement * Time.deltaTime, speech * Time.deltaTime, 0));
        }
        else
        {
            if (right == true)
                transform.Translate(new Vector3(movement * Time.deltaTime, -speech * Time.deltaTime, 0));
            if (left == true)
                transform.Translate(new Vector3(-movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), Mathf.Clamp(transform.position.y, -4.4f, 4.35f), transform.position.z);
        if (transform.position.x == 2.3f)
        {
            right = false;
            left = true;
        }
        if (transform.position.x == -2.3f)
        {
            right = true;
            left = false;
        }
        if (transform.position.y == 4.35f)
        {
            up = false;
        }
    }
    void LateUpdate()
    {
        if (this.transform.position.y == -4.4f)
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballnhanh"].Enqueue(this.gameObject);
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
}
