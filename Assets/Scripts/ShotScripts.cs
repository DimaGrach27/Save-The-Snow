using UnityEngine;

public class ShotScripts : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] float gross;

    [SerializeField] GameObject colliderSphere;

    private Transform target;

    private ParticleSystem partSys;

    private MeshRenderer mesh;

    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private SphereCollider coll;
    private float collRadius = 0.1f;

    private bool isShuting;
    private bool isInTarget;

    public static bool isAlive;

    void Awake()
    {
        partSys = GetComponent<ParticleSystem>();
        coll = GetComponent<SphereCollider>();
        mesh = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        colliderSphere.SetActive(false);
        isAlive = true;
        transform.localScale = Vector3.zero;
        isShuting = false;
        isInTarget = false;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        target = GameObject.FindWithTag("StartPoint").transform;
    }


    void Update()
    {
        coll.radius = collRadius;

        if (isShuting)
            Shot();
        else
        {
            if (isInTarget)
                return;
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
            

        if (Fire.fire)
        {
            transform.localScale += Vector3.one * gross * Time.deltaTime;
        }
        else if (!Fire.fire)
        {
            audioSource.Stop();
            isShuting = true;
        }
    }

    void Shot()
    {
        transform.position += transform.forward * 5f * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(audioClip);
            mesh.enabled = false;
            isInTarget = true;
            isShuting = false;
            coll.enabled = false;
            colliderSphere.SetActive(true);
            partSys.Play();
            Destroy(gameObject, 3f);
            isAlive = false;
        }
    }
}
