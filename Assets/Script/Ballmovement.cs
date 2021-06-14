using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    [SerializeField] private GameObject dieAudio;
    private float speech,movement;
    [HideInInspector] public bool right, left;
    void Start()
    {
        movement = 1.5f;
        speech = 4.25f;
        right = false;
        left = true;
    }
    void Update()
    {
        if(right == true)
            transform.Translate(new Vector3(movement*Time.deltaTime, -speech * Time.deltaTime, 0));
        if(left == true)
            transform.Translate(new Vector3(-movement * Time.deltaTime, -speech * Time.deltaTime, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.4f,2.4f), Mathf.Clamp(transform.position.y, -4.4f, 5), transform.position.z);
        if (transform.position.x == 2.4f)
        {
            right = false;
            left = true;
        }
        if (transform.position.x == -2.4f)
        {
            right = true;
            left = false;
        }
    }
    void LateUpdate()
    {
        if (this.transform.position.y == -4.4f)
        {
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Ballchilrent1"].Enqueue(this.gameObject);
            right = false;
            left = true;
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
}
