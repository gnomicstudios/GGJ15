using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour
{
    public int minCount = 10;
    public int maxCount = 20;
    public float angle = 10f;
    public int minDist = 25;
    public int maxDist = 35;
    public Transform[] prefab;
    public int count;
    public float mapSize = 500.0f;
    private int currentCount;

    // Use this for initialization
    void Start()
    {
        if(prefab.Length == 0)
        {
            return;
        }
        count = Random.Range(minCount, maxCount - 1);
        currentCount = 0;
        if(angle >= 90f)
        {
            angle = 90f;
        }

        AddResources(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
    }

    void AddResources(Vector3 pos, Vector3 prevPos)
    {
        if(System.Math.Abs(pos.x) >= mapSize * 0.5f || System.Math.Abs(pos.z) >= mapSize * 0.5f)
        {
            return;
        }

        currentCount++;
        Transform t = (Transform)Instantiate(prefab[Random.Range(0, prefab.Length - 1)],
                                                        pos,
                                                        Quaternion.identity);
        t.gameObject.transform.parent = gameObject.transform;

        if(currentCount >= count)
        {
            return;
        }

        Vector3 dir;
        if(prevPos == pos)
        {
            Vector3 randVec = new Vector3(Random.Range(-2, 2), 0f, Random.Range(-2, 2));
            randVec.Normalize();
            if((pos + randVec).sqrMagnitude <= pos.sqrMagnitude)
            {
                randVec.x = -randVec.x;
            }
            randVec *= Random.Range(minDist, maxDist);
            
            AddResources(pos + randVec, pos);

            dir = -randVec;
        }
        else
        {
            dir = pos - prevPos;
        }

        dir = Quaternion.AngleAxis(Random.Range(-angle, angle), Vector3.up) * dir;

        AddResources(pos + dir, pos);
    }
}
