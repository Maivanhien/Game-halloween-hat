using UnityEngine;

public class Destroycamkysi : MonoBehaviour
{
    private void OnMouseDown()
    {
        Objectpooler.Instance.SpawnFromPool("Kysido", new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        Objectpooler.Instance.poolDictionary["Kysicam"].Enqueue(this.gameObject);
    }
}
