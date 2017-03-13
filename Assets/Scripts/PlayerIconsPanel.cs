using UnityEngine;
using System.Collections;

public class PlayerIconsPanel : MonoBehaviour
{
    float width;
    RectTransform rectXform;
    Players players;

	// Use this for initialization
	void Start () {
        players = FindObjectOfType<Players> ();
        rectXform = this.GetComponent<RectTransform> ();
        width = rectXform.rect.width;
        Debug.Log (width);
	}
	
	// Update is called once per frame
	void Update ()
    {
        rectXform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, players.activePlayers.Count * width);

        int i = 0;
        var icons = this.GetComponentsInChildren<PlayerIcon> ();
        foreach (var playerIcon in icons)
        {
            if (i < players.activePlayers.Count)
            {
                playerIcon.player = players.activePlayers[i];
                playerIcon.gameObject.SetActive(true);
                (playerIcon.transform as RectTransform).anchoredPosition = new Vector3(5 + width * i, 0.0f);
            }
            else
            {
                playerIcon.gameObject.SetActive(false);
            }
            i++;
        }
	}
}
