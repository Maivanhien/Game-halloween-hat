using UnityEngine;

public class Destroydokysi : MonoBehaviour
{
    private void OnMouseDown()
    {
        Objectpooler.Instance.SpawnFromPool("Kysi", new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Kysido"].Enqueue(this.gameObject);
    }
}
