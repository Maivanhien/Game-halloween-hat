using UnityEngine;

public class Destroykysixanh : MonoBehaviour
{
    private int number;
    private void Start()
    {
        number = 0;
    }
    private void Update()
    {
        if(number==15)
        {
            Objectpooler.Instance.SpawnFromPool("Kysi", new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
            Objectpooler.Instance.poolDictionary["Kysixanh"].Enqueue(this.gameObject);
            number = 0;
        }
    }
    private void OnMouseDrag()
    {
        number = number + 1;
    }
}
