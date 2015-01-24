using UnityEngine;

public class UIManager : MonoBehaviour
{    
    public void StartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
