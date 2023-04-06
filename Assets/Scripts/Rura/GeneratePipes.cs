using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePipes : MonoBehaviour {
    public GameObject pipePrefab;

    public GameObject leftColumne;
    public GameObject rightColumne;
    public List<Color> pipeColorLeft = new List<Color>();
    public List<Color> pipeColorRight = new List<Color>();

    private void Start() {
        AddColors(pipeColorLeft);
        AddColors(pipeColorRight);

        for (int i = 0; i < 5; i++) {
            int color = Random.Range(0, pipeColorLeft.Count - 1);

            CreateAPipe(color, leftColumne.transform, pipeColorLeft);
            pipeColorLeft.RemoveAt(color);
        }

        for (int i = 0; i < 5; i++) {
            int color = Random.Range(0, pipeColorRight.Count - 1);

            CreateAPipe(color, rightColumne.transform, pipeColorRight);
            pipeColorRight.RemoveAt(color);
        }
    }

    private void CreateAPipe(int color, Transform columne, List<Color> pipeColor) {
        GameObject pipe = Instantiate(pipePrefab, columne);
        pipe.GetComponent<PipeInfo>().color = pipeColor[color];
    }

    public void AddColors(List<Color> pipeColor) {
        pipeColor.Add(Color.blue);
        pipeColor.Add(Color.red);
        pipeColor.Add(Color.green);
        pipeColor.Add(Color.yellow);
        pipeColor.Add(Color.cyan);
    }
}
