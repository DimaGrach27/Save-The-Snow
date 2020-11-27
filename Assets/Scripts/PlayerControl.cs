using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPoint;

    RaycastHit hit;

    void Start()
    {
        //Time.timeScale = 0.1f;
    }


    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.Raycast(ray, out hit, 100f);

        //transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        if (!GameManager.Win)
        {
            if (Fire.fire && !ShotScripts.isAlive)
                Shot();

            if (Fire.fire)
            {
                transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;
            }

            if (MoveHeandler.leftRotation != 0)
            {
                transform.position += Vector3.forward * Time.deltaTime;
            }
            Rotation();
        }

    }

    void Shot()
    {
        transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
        Instantiate(shot, shotPoint.position, transform.rotation);
    }

    void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0f, (Left.left * 0.5f) + (Right.right * 35f) * Time.deltaTime, 0f);
    }
}
