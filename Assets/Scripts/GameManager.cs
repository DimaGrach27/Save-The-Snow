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

    [SerializeField] GameObject loseText;
    public static bool Lose;

    [SerializeField] GameObject winText;
    public static bool Win;

    private void Start()
    {
        Win = false;
        Lose = false;
        loseText.SetActive(false);
        winText.SetActive(false);
    }

    private void Update()
    {
        if (Lose)
        {
            Invoke("ReloadScene", 2f);
            loseText.SetActive(true);
        }
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

    void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
