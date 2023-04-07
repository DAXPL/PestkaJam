using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTrackChoose : MonoBehaviour {
    public GenerateTrainTracks generateTrainTracks;
    public GameObject END;
    public GameObject jakku;
    public GameObject morasko;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(200, 0);
        StartCoroutine(MyOwnUpdateEnumerator());
    }
    
    IEnumerator MyOwnUpdateEnumerator() {
        while (true) {
            yield return null;
            float distance = Vector3.Distance(transform.position, generateTrainTracks.allTrainTracks[generateTrainTracks.randomTrainTrack].transform.position);
            float distanceToEnd = Vector3.Distance(transform.position, END.transform.position);

            if (distanceToEnd <= 10f) {
                OnEndColide();
                yield break;
            }

            if (distance <= 15f) {
                if (generateTrainTracks.allTrainTracks[generateTrainTracks.randomTrainTrack].GetComponent<Image>().color == Color.white) {
                    yield return null;
                } else {
                    TrainBreak();
                }
            }
        }
    }

    public void TrainBreak() {
        Debug.Log("THE TRAIN DIED");
        StartCoroutine(KampusGaming());
    }

    public void OnEndColide() {
        Debug.Log("ENDDDDDDDDDDDDDDDDDDDDDDDDDD");
        StartCoroutine(JakkuGaming());
    }
    IEnumerator JakkuGaming()
    {
        jakku.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    IEnumerator KampusGaming()
    {
        morasko.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
