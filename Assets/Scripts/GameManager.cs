using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager() { }

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }


    [SerializeField] GameObject winText;
    public static bool Win;

    private void Start()
    {
        Win = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Win = true;
            Invoke("ReloadScene", 3f);
            winText.SetActive(true);
        }
    }

    public void LoseGame()
    {
        ReloadScene();
    }

    void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
