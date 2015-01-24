using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeCounter = 0f;
    public bool running = true;
    
    void FixedUpdate()
    {
        if(running)
        {
            TimeCounter += Time.fixedDeltaTime;
            gameObject.GetComponent<Text>().text = TimeCounter.ToString("F2");
        }
    }
}
