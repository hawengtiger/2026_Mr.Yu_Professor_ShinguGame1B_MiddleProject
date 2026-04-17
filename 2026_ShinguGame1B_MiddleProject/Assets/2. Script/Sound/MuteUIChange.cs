using UnityEngine;
using UnityEngine.UI;

public class MuteUIChange : MonoBehaviour
{
    public enum SoundType { BGM, SFX }

    public SoundType type;
    public Image buttonImage;
    public Sprite onSprite;
    public Sprite offSprite;

    private bool isMute;

    void Start()
    {
        UpdateUI();
    }

    public void OnClick()
    {
        if (type == SoundType.BGM)
            SoundManager.Instance.MuteMusic();
        else
            SoundManager.Instance.MuteSFX();

        UpdateUI();
    }

    void UpdateUI()
    {
        if ((type == SoundType.BGM))
        {
            isMute = SoundManager.Instance.musicSource.mute;
        }
        else
        {
            isMute = SoundManager.Instance.sfxSource.mute;
        }


        buttonImage.sprite = isMute ? offSprite : onSprite;
    }
}