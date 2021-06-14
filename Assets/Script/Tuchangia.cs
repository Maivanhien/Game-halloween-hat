using UnityEngine;

public class Tuchangia : MonoBehaviour
{
    public GameObject dieAudio;
    private float rotation;
    void Start()
    {
        rotation = 0;
    }

    void Update()
    {
        rotation -= 135 * Time.deltaTime;
        rotation = rotation % 360;
        transform.localEulerAngles = new Vector3(0f, 0f, rotation);
    }
    void LateUpdate()
    {
        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 10f), transform.position.z);
        if (this.transform.position.y == -4.4f)
        {
            Destroy(transform.parent.gameObject);
            Instantiate(dieAudio, this.transform.position, Quaternion.identity);
            Gamemanager.isGameOver = true;
        }
    }
}
