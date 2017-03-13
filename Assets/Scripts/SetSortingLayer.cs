using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{
    public string sortingLayerName;        // The name of the sorting layer .
    public int sortingOrder;            //The sorting order

    void Start()
    {
        // Set the sorting layer and order.
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = sortingLayerName;
        renderer.sortingOrder = sortingOrder;
    }
}