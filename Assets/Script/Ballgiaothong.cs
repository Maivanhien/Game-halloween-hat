using UnityEngine;

public class Ballgiaothong : MonoBehaviour
{
    [SerializeField] private GameObject ballExploded;
    private float time;
    void Start()
    {
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.2f) time -= 1.2f;
    }
    void OnMouseDown()
    {
        if (time < 0.4f) Gamemanager.changeTime = 1;
        else if (time < 0.8f) Gamemanager.changeTime = 2;
        else Gamemanager.changeTime = 3;
        Instantiate(ballExploded, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
