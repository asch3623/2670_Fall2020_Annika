using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    
    private Text scoreText;
   public IntData score;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    void Update()
    {
        scoreText.text = "Lives: " + score.value.ToString();
    }
}
