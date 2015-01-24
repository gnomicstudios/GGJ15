using UnityEngine;

public class Play : MonoBehaviour
{    
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void ReplayGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
