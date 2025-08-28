using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  //card flip , matching, mismatching,game over
   public static SoundManager Instance { get; private set; }

    [SerializeField]AudioClip card_Flip;
    [SerializeField]AudioClip card_match;
    [SerializeField]AudioClip card_mismatch;
    [SerializeField]AudioClip game_Over;

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
    }

    private void GameManager_onCardMismatch(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void GameManager_onCardMatch(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    public void PlaySound(Vector3 position,AudioClip audioclip)
    { 
      //audioSource.Play(position,audioclip);
    }
}
