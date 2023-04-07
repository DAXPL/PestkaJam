using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracktrainInfo : MonoBehaviour {
    public Color trackColor;

    private void Start() {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart() {
        yield return new WaitForSeconds(0.1f);
        if (TryGetComponent<Image>(out Image image)) {
            image.color = trackColor;
        }
    }
}
