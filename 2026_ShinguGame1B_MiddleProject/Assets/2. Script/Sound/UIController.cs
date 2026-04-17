using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;  // 음악 볼륨과 효과음 볼륨을 조절할 슬라이더

    void Start()
    {
        // 저장된 음악 볼륨 값을 슬라이더에 반영
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        // 저장된 효과음 볼륨 값을 슬라이더에 반영
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    // 뮤트 버튼 클릭 시 음악 뮤트 상태 토글
    public void MuteMusic()
    {
        SoundManager.Instance.MuteMusic();  // AudioManager에서 MuteMusic 함수 호출
    }

    // 뮤트 버튼 클릭 시 효과음 뮤트 상태 토글
    public void MuteSFX()
    {
        SoundManager.Instance.MuteSFX();  // AudioManager에서 MuteSFX 함수 호출
    }

    // 음악 볼륨 슬라이더 값 변경 시 호출되는 함수
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(_musicSlider.value);  // 슬라이더 값에 맞게 음악 볼륨 변경
    }

    // 효과음 볼륨 슬라이더 값 변경 시 호출되는 함수
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(_sfxSlider.value);  // 슬라이더 값에 맞게 효과음 볼륨 변경
    }
}