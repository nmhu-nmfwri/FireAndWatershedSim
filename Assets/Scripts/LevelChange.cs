using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string newLevel;

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(newLevel);
    }
}
