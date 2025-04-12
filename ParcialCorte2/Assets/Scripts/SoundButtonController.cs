using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButtonImage : MonoBehaviour
{
    [Header("Referencias")]
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool soundOn;

    void Start()
    {
        soundOn = PlayerPrefs.GetInt("sound", 1) == 1;
        ApplySoundSetting();
        UpdateButtonImage();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetInt("sound", soundOn ? 1 : 0);
        ApplySoundSetting();
        UpdateButtonImage();
    }

    private void ApplySoundSetting()
    {
        AudioListener.volume = soundOn ? 1 : 0;
    }

    private void UpdateButtonImage()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = soundOn ? soundOnSprite : soundOffSprite;
        }
    }
}