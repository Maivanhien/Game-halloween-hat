using UnityEngine;

public class Destroycrow : MonoBehaviour
{
    void OnMouseDown()
    {
        if(this.gameObject.tag == "VCrow")
        {
            Objectpooler.Instance.SpawnFromPool("Crowlua", new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Objectpooler.Instance.SpawnFromPool("Crowlua", new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Crow"].Enqueue(this.gameObject);
        }
    }
}
