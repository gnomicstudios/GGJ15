using UnityEngine;

public class EnableMeshRendererOnStart : MonoBehaviour {
    public bool enable = true;

    void Start () {
        GetComponent<MeshRenderer>().enabled = enable;
	}
}
