using UnityEngine;

public class Destroysupperman : MonoBehaviour
{
    [SerializeField] private GameObject thorBua;
    private int rand, rand1;
    
    void OnMouseDown()
    {
        rand = Random.Range(1, 3);
        rand1 = Random.Range(1, 7);
        if (rand == 1)
        {
            if (rand1 == 1)
                Objectpooler.Instance.SpawnFromPool("Kysivang", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            else if (rand1 == 2)
                Objectpooler.Instance.SpawnFromPool("Ball", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            else if (rand1 == 3)
                Objectpooler.Instance.SpawnFromPool("Crow", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            else if (rand1 == 4)
                Objectpooler.Instance.SpawnFromPool("Kysixanh", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            else if (rand1 == 5)
                Objectpooler.Instance.SpawnFromPool("Pumpkin", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            else
                Instantiate(thorBua, new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
        }
        else Objectpooler.Instance.SpawnFromPool("Supperlon", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
        Objectpooler.Instance.SpawnFromPool("Supperexploded", new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Supperman"].Enqueue(this.gameObject);
    }
}
