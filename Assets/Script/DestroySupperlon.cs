using UnityEngine;

public class DestroySupperlon : MonoBehaviour
{
    void OnMouseDown()
    {
        Objectpooler.Instance.SpawnFromPool("Supperman1", new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Supperlon"].Enqueue(this.gameObject);
    }
}
