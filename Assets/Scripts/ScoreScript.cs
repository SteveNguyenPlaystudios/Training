using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    private Text score;
    // Start is called before the first frame update
    public void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}
