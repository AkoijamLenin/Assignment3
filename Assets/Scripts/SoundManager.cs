using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  //card flip , matching, mismatching,game over
   public static SoundManager Instance { get; private set; }

    [SerializeField]AudioClip card_Flip_Sound;
    [SerializeField]AudioClip card_match_Sound;
    [SerializeField]AudioClip card_mismatch_Sound;
    [SerializeField]AudioClip game_Over_Sound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        GameManager.Instance.onCardCheck += GameManager_onCardCheck;
        GameManager.Instance.onGameOver += GameManager_onGameOver;
    }

    private void GameManager_onCardCheck(object sender, GameManager.CardActionEventArgs e)
    {
        if (e.isMatched)
        {
            PlaySound(Camera.main.transform.position, card_match_Sound);
        }
        else
        {
            PlaySound(Camera.main.transform.position, card_mismatch_Sound);
        }
    }

    public void Play_Card_FlipSound()
    {
        PlaySound(Camera.main.transform.position, card_Flip_Sound);
    }
    private void GameManager_onGameOver(object sender, System.EventArgs e)
    {
        PlaySound(Camera.main.transform.position, game_Over_Sound);
    }

    private void GameManager_onCardMismatch(object sender, System.EventArgs e)
    {
        PlaySound(Camera.main.transform.position,card_mismatch_Sound);
    }

    private void GameManager_onCardMatch(object sender, System.EventArgs e)
    {
        PlaySound(Camera.main.transform.position, card_match_Sound); 
    }

    private void PlaySound(Vector3 position,AudioClip audioclip,float volume=1)
    {
        AudioSource.PlayClipAtPoint(audioclip,position, volume);
    }
}
