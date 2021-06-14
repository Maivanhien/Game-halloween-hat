using UnityEngine;

public class Hiepsidissolve : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private GameObject hiepSi1;
    private float dissolveAmount;
    void Start()
    {
        dissolveAmount = 1f;
    }
    
    void Update()
    {
        dissolveAmount = Mathf.Clamp01(dissolveAmount - 2f*Time.deltaTime);
        material.SetFloat("_DissolveAmount", dissolveAmount);
        if (dissolveAmount == 0)
        {
            if(this.transform.position.x>=0)
                Instantiate(hiepSi1, new Vector3(Mathf.Clamp(Random.Range(-2.3f, -0.3f),-2.4f,2.4f), Mathf.Clamp(Random.Range(transform.position.y - 0.7f, transform.position.y + 1.4f), -4.4f, 10f), transform.position.z), Quaternion.identity);
            else
                Instantiate(hiepSi1, new Vector3(Mathf.Clamp(Random.Range(0.5f, 2.4f), -2.4f, 2.4f), Mathf.Clamp(Random.Range(transform.position.y - 0.7f, transform.position.y + 1.4f), -4.4f, 10f), transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}