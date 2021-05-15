using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public static AudioManager instance;

    Coroutine fadeIn = null;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayBGM(1);
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        //0: Death

        if (soundToPlay < sfx.Length) { sfx[soundToPlay].Play(); }
    }

    public void PlayBGM(int musicToPlay)
    {
        if (!bgm[musicToPlay].isPlaying)
        {
            StopMusic(musicToPlay);

            if (musicToPlay < bgm.Length)
            {
                //bgm[musicToPlay].Play(); //1st Option.
                fadeIn = StartCoroutine(FadeIn(musicToPlay, 0.01f, 1.0f)); //2nd Option.
            }
        }
    }

    public void StopMusic(int musicToPlay)
    {
        if (fadeIn != null)
        {
            StopCoroutine(fadeIn);
        } 

        for (int i = 0; i < bgm.Length; i++) 
        {
            if (i != musicToPlay)
            {
                StartCoroutine(FadeOut(i, 0.01f)); //2nd Option.
            }
        }
    }

    IEnumerator FadeIn (int track, float speed, float maxVolume)
    {
        bgm[track].volume = 0.0f;
        bgm[track].Play(); //I don't know if this sould go here.

        float audioVolume = bgm[track].volume;

        while (bgm[track].volume <= maxVolume)
        {
            audioVolume += speed;
            bgm[track].volume = audioVolume;

            if (bgm[track].volume >= maxVolume)
            {
                bgm[track].volume = maxVolume;

                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut(int track, float speed)
    {
        float audioVolume = bgm[track].volume;

        while (bgm[track].volume >= 0.0f)
        {
            audioVolume -= speed;
            bgm[track].volume = audioVolume;

            if (bgm[track].volume <= 0.0f)
            {
                bgm[track].volume = 0.0f;
                bgm[track].Stop();

                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
