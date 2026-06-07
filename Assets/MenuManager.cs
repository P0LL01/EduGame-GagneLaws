using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Ξαναφορτώνει την τωρινή σκηνή από την αρχή
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Κλείνει την εφαρμογή
        Application.Quit();
        Debug.Log("Το παιχνίδι έκλεισε!"); // Αυτό φαίνεται μόνο μέσα στον Editor
    }
}