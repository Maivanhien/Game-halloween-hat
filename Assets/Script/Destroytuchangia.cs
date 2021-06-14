using UnityEngine;

public class Destroytuchangia : MonoBehaviour
{
    [SerializeField] private GameObject vongTuchangia;
    void OnMouseDown()
    {
        Instantiate(vongTuchangia, new Vector3(transform.position.x, transform.position.y, transform.position.z + 4f), Quaternion.identity);
        Destroy(gameObject);
    }
}
