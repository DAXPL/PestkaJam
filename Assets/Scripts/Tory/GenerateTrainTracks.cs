using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateTrainTracks : MonoBehaviour {
    public GameObject trainTrackPrefab;
    public List<GameObject> allTrainTracks;

    public List<GameObject> allTrainTracksToChoose;
    public GameObject chooseATrack;

    public List<Color> colours = new List<Color>();

    public int randomTrainTrack;

    private void Start() {
        for (int i = 0; i < 7; i++) {
            GameObject trainTrack = Instantiate(trainTrackPrefab, gameObject.transform);
            allTrainTracks.Add(trainTrack);
        }

        int randomColourTrack = Random.Range(0, colours.Count - 1);
        randomTrainTrack = Random.Range(2, allTrainTracks.Count - 1);
        allTrainTracks[randomTrainTrack].GetComponent<TracktrainInfo>().trackColor = colours[randomColourTrack];
        colours.RemoveAt(randomColourTrack);

        for (int i = 0; i < 3; i++) {
            GameObject trainTrack = Instantiate(trainTrackPrefab, chooseATrack.transform);

            int randomColour = Random.Range(0, colours.Count - 1);
            trainTrack.GetComponent<TracktrainInfo>().trackColor = colours[randomColour];
            colours.RemoveAt(randomColour);
            trainTrack.GetComponent<Button>().onClick.AddListener(delegate { OnClickChoose(trainTrack, randomTrainTrack); });
            allTrainTracksToChoose.Add(trainTrack);
        }

        allTrainTracksToChoose[Random.Range(0, allTrainTracksToChoose.Count - 1)].GetComponent<TracktrainInfo>().trackColor = allTrainTracks[randomTrainTrack].GetComponent<TracktrainInfo>().trackColor;
    }

    public void OnClickChoose(GameObject track, int randomTrainTrack) {
        if (track.GetComponent<TracktrainInfo>().trackColor == allTrainTracks[randomTrainTrack].GetComponent<TracktrainInfo>().trackColor) {
            allTrainTracks[randomTrainTrack].GetComponent<Image>().color = Color.white;
        }
    }
}
