using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public static AudioManager instance;

    private static bool keepFadingIn;
    private static bool keepFadingOut;

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
            StopMusic();

            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play(); //1st Option.
                //FadeIn(musicToPlay, 0.1f, 1.0f); //2nd Option.
            }
        }
    }

    public void StopMusic()
    {
        for (int i = 0; i < bgm.Length; i++) 
        {
            bgm[i].Stop(); //1st Option.
            //FadeOut(i, 0.1f); //2nd Option.
        }
    }

    IEnumerator FadeIn (int track, float speed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;

        bgm[track].volume = 0.0f;
        bgm[track].Play(); //I don't know if this sould go here.

        float audioVolume = bgm[track].volume;

        while ((bgm[track].volume <= maxVolume) && keepFadingIn)
        {
            audioVolume += speed;
            bgm[track].volume = audioVolume;

            if (bgm[track].volume >= maxVolume)
            {
                keepFadingIn = false;
                bgm[track].volume = maxVolume;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator FadeOut(int track, float speed)
    {
        keepFadingIn = false;
        keepFadingOut = true;

        float audioVolume = bgm[track].volume;

        while ((bgm[track].volume >= speed) && keepFadingOut)
        {
            audioVolume -= speed;
            bgm[track].volume = audioVolume;

            if (bgm[track].volume <= 0.0f)
            {
                keepFadingOut = false;
                bgm[track].volume = 0.0f;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
