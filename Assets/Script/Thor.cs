using UnityEngine;

public class Thor : MonoBehaviour
{
    public GameObject thor,bua, thorSamSet;
    private void OnMouseDown()
    {
        int i = Random.Range(1, 3);
        if(i == 1)
        {
            Instantiate(thor, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(bua, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
        }
        else
        {
            Objectpooler.Instance.SpawnFromPool("Samset", new Vector3(0f, 1.15f, 0f), Quaternion.identity);
            Instantiate(thorSamSet, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
