using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerIcon : MonoBehaviour, IPointerDownHandler {

    internal PlayerController player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Clicked()
    {
    }

    #region IPointerDownHandler implementation

    public void OnPointerDown (PointerEventData eventData)
    {
        FindObjectOfType<TerrainSelector> ().disableNextClick = true;
        SelectionManager.Instance.CurrentSelectable = player;
    }

    #endregion
}
