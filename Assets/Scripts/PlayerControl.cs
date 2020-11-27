using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPoint;

    private Rigidbody rb;

    private MeshRenderer mesh;
    [SerializeField] Material criticalBlue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        if (!GameManager.Win && !GameManager.Lose)
        {
            if (Fire.fire && !ShotScripts.isAlive)
                Shot();

            if (Fire.fire)
            {
                transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;
            }

            if (MoveHeandler.move)
            {
                rb.isKinematic = false;
                transform.position += Vector3.forward * Time.deltaTime;
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

            Rotation();
        }

        if (transform.localScale.x < 0.3f)
            GameManager.Lose = true;
        if (transform.localScale.x < 0.38f)
            mesh.material = criticalBlue;

    }

    void Shot()
    {
        transform.localScale -= new Vector3(0.023f, 0.023f, 0.023f);
        Instantiate(shot, shotPoint.position, transform.rotation);
    }

    void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0f, (Left.left * 0.5f) + (Right.right * 35f) * Time.deltaTime, 0f);
    }
}
