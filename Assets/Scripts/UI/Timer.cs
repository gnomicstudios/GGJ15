using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeCounter = 0f;
    
    void FixedUpdate()
    {
        TimeCounter += Time.fixedDeltaTime;
        gameObject.GetComponent<Text>().text = TimeCounter.ToString("F2");
    }
}
