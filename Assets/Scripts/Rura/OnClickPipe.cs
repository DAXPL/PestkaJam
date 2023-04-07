using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPipe : MonoBehaviour {
    public List<LineRenderer> pipes = new List<LineRenderer>();

    public void ConnectPipes(GameObject pipe) {
        if (pipe.GetComponent<PipeInfo>().used) {
            return;
        }

        pipe.GetComponent<PipeInfo>().used = true;

        pipes.Add(pipe.GetComponent<LineRenderer>());

        if (pipes.Count == 2) {
            pipes[0].SetPosition(0, pipes[0].transform.position);
            pipes[0].SetPosition(1, pipe.transform.position);

            pipes[0].startColor = pipes[0].GetComponent<PipeInfo>().color;
            pipes[0].endColor = pipes[0].GetComponent<PipeInfo>().color;
            
            StartCoroutine(CheckColors(pipe));
        }
    }

    IEnumerator CheckColors(GameObject pipe) {
        yield return new WaitForSeconds(2);

        if (pipes[1].GetComponent<PipeInfo>().color == pipes[0].GetComponent<PipeInfo>().color) {
            pipes[0].GetComponent<Button>().interactable = false;
            pipes[1].GetComponent<Button>().interactable = false;

            GetComponent<GeneratePipes>().allPipes.Remove(pipes[0].gameObject);
            GetComponent<GeneratePipes>().allPipes.Remove(pipes[1].gameObject);

            pipes.Clear();

            if (GetComponent<GeneratePipes>().allPipes.Count == 0) {
                WonTheGame();
            }
            yield break;
        }

        pipes[0].SetPosition(0, Vector3.zero);
        pipes[0].SetPosition(1, Vector3.zero);

        pipes[0].GetComponent<PipeInfo>().used = false;
        pipes[1].GetComponent<PipeInfo>().used = false;

        pipes.Clear();
    }

    public void WonTheGame() {
        Debug.Log("YOU WON");
    }
}
