using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
    public static long score;
    public static float passFailScore;
    public AudioClip BGM;
    AudioSource source;
    public static void beatHit()
    {
        Debug.Log("HIT!");
        GameController.score += 100;
        GameController.passFailScore += .05f;
        if(passFailScore > 1)
        {
            passFailScore = 1;
        }
    }
    public static void beatMiss()
    {
        Debug.Log("MISS!");
        passFailScore -= .1f;
        if(passFailScore < 0)
        {
            passFailScore = 0;
        }
    }

	void Start () {
        score = 0;
        passFailScore = 1;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(BGM);
	}
	
	// Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Score");
        obj.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
	}
}
