using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeInfo : MonoBehaviour {
    public Color color;
    public bool used;

    private void Start() {
        used = false;
        GetComponent<Image>().color = color;
        GetComponent<Button>().onClick.AddListener(delegate { OnClickPipe.OCP.ConnectPipes(gameObject); });
    }
}
