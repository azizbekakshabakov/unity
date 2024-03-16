using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();

        // не удолять сцену
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != null && instance != this) {
            //убрать дубликат
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip sound) {
        source.PlayOneShot(sound);
    }
}
