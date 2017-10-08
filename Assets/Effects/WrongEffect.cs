using UnityEngine;
using UnityEngine.UI;

public class WrongEffect : Effect
{
    [SerializeField] Image overlay;
    [SerializeField] float fadeOutEndTime;
    [SerializeField] Color overlayColor;

    float fadeOutTime;

    void Start()
    {
        fadeOutTime = fadeOutEndTime;
    }

    public override void Play()
    {
        CrackleAudio.SoundController.PlaySound("wrong");
        overlay.color = overlayColor;
        fadeOutTime = 0;
    }

    void Update()
    {
        if (fadeOutTime < fadeOutEndTime)
        {
            fadeOutTime += Time.deltaTime;
            overlay.color = Color.Lerp(overlay.color, Color.clear, fadeOutTime / fadeOutEndTime);
        }
    }
}
