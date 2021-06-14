using UnityEngine;

public class Destroyheart : MonoBehaviour
{
    [SerializeField] private GameObject heart, heart1;
    void OnMouseDown()
    {
        if (Gamemanager.heart == 2)
        {
            Gamemanager.heart = 3;
            Instantiate(heart, new Vector3(1.2f, 4.68f, 0), Quaternion.identity);
        }
        if (Gamemanager.heart == 1)
        {
            Gamemanager.heart = 2;
            Instantiate(heart1, new Vector3(1.82f, 4.68f, 0), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
