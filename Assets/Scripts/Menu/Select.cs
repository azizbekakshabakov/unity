using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;

    private void Awake() {
        rect = GetComponent<RectTransform>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ChangePosition(1);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            Interact();
        }
    }

    private void ChangePosition(int change) {
        currentPosition += change;

        if (currentPosition < 0) {
            currentPosition = options.Length - 1;
        } else if (currentPosition > options.Length - 1) {
            currentPosition = 0;
        }

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, rect.position.z);
    }

    private void Interact() {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
