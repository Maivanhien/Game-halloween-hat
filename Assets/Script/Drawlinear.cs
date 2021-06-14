using UnityEngine;

public class Drawlinear : MonoBehaviour
{
    private CircleCollider2D circle;
    private ParticleSystem particle;
    private Rigidbody2D rb;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        circle = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        circle.enabled = false;
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float velocity = (pos - rb.position).magnitude * Time.fixedDeltaTime;
            if (velocity >= 0.0003f)
            {
                circle.enabled = true;
                ParticleSystem.EmissionModule particle1 = particle.emission;
                particle1.enabled = true;
            }
            else
            {
                circle.enabled = false;
                ParticleSystem.EmissionModule particle1 = particle.emission;
                particle1.enabled = false;
            }
            rb.MovePosition(pos);
        }
    }
}
