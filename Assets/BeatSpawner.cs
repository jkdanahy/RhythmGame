using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BeatSpawner : MonoBehaviour {
    public float BPM;
    public char spawnerLocation = 'L';
    public TextAsset testFile = null;
    float beatCounter = 0;
    List<float> beatTimingList = new List<float>();
    bool doubleTime = false;
    int doubleTimeCount = 3;
    int singleTimeCount = 2;
    public GameObject beat;
	// Use this for initialization
	void Start ()
    {
        beatTimingList.Add(13f);
        string line;

        char[] archDelim = new char[] { '\r', '\n' };
        string[] lines = testFile.text.Split(archDelim,StringSplitOptions.RemoveEmptyEntries); 
        Debug.Log(testFile.text);
        for (int i = 0; i < lines.Length; i++)
        {
            line = lines[i];
            if (line[0] == spawnerLocation)
            {
                for (int j = 1; j < line.Length; j++)
                {
                    switch (line[j])
                    {
                        case 'W':
                            beatTimingList.Add(60 / BPM);
                            break;
                        case 'H':
                            beatTimingList.Add(30 / BPM);
                            break;
                        case 'Q':
                            beatTimingList.Add(15 / BPM);
                            break;
                        case 'R':
                            float restToAdd = 0f;
                            switch (line[j + 1])
                            {
                                case 'W':
                                    restToAdd = (60 / BPM);
                                    break;
                                case 'H':
                                    restToAdd = (30 / BPM);
                                    break;
                                case 'Q':
                                    restToAdd = (15 / BPM);
                                    break;
                            }
                            beatTimingList[beatTimingList.Count - 1] += restToAdd;
                            j++;
                            break;
                    }
                }
            }
        }
        beatTimingList.RemoveAt(beatTimingList.Count-1);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (beatTimingList.Count > 0)
        {
            beatCounter += Time.deltaTime;
            if (beatCounter >= beatTimingList[0])
            {
                GameObject newBoy = Instantiate(beat, transform.position, new Quaternion()) as GameObject;
                beatCounter -= beatTimingList[0];
                beatTimingList.RemoveAt(0);
            }
        }
	}
}
