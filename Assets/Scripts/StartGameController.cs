using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{

    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _startBall;

    private void Update()
    {
        GameStart();
    }
    private void GameStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Space is Pressed");
            _startText.SetActive(false);
            _startBall.SetActive(true);
        }
    }

    private void GameEnd()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}