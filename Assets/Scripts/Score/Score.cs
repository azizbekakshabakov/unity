using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text;
    private float score = 0f;

    private void Awake() {
        text.text = score.ToString();
    }

    public void IncrementText(float incrementValue) {
        score += incrementValue;

        text.text = score.ToString();
    }
}
