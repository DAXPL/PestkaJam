using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeInfo : MonoBehaviour {
    public Color color;
    public bool used;
    public OnClickPipe onClickPipe;

    private void Awake() {
        onClickPipe = GameObject.Find("Main Camera").GetComponent<OnClickPipe>();
    }

    private void Start() {
        used = false;
        GetComponent<Image>().color = color;
        GetComponent<Button>().onClick.AddListener(delegate { onClickPipe.ConnectPipes(gameObject); });
    }
}
