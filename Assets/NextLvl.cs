using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLvl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the next scene (by build index)
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
