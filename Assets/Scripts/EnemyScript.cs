using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private ParticleSystem partSys;
    private Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
        partSys = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shot")
        {
            partSys.Stop();
            coll.enabled = false;
        }

        if(collision.gameObject.tag == "Player")
        {
            GameManager.Lose = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            partSys.Stop();
            coll.enabled = false;
        }
    }
}
