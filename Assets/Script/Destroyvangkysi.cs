using UnityEngine;

public class Destroyvangkysi : MonoBehaviour
{
    private void OnMouseDown()
    {
        Objectpooler.Instance.SpawnFromPool("Kysicam", new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Kysivang"].Enqueue(this.gameObject);
    }
}
