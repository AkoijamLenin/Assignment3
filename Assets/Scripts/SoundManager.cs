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
        GameManager.Instance.onCardMatch += GameManager_onCardMatch;
        GameManager.Instance.onCardMismatch += GameManager_onCardMismatch;
        GameManager.Instance.onGameOver += GameManager_onGameOver;
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

    public void PlaySound(Vector3 position,AudioClip audioclip,float volume=1)
    {
        AudioSource.PlayClipAtPoint(audioclip,position, volume);
    }
}
