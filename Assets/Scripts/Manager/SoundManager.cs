using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource bgm ; 
    [SerializeField] private SoundDatabase database;
    [SerializeField] private AudioMixer mixer;
    AudioSource playling ; 
    private Queue<AudioSource> sfxPool;
    private int poolSize = 15;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);


        bgm = GetComponent<AudioSource>();
        // Create pool
        sfxPool = new Queue<AudioSource>();
        for (int i = 0; i < poolSize; i++)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            src.playOnAwake = false;
            src.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
            sfxPool.Enqueue(src);
        }
    }

    public void PlaySFX(string key)
    {
        SoundEntry s = database.sfxs.Find(x => x.key == key);
        if (s == null || s.clip == null) return;

        // Nếu pool rỗng → tạo thêm hoặc return để tránh crash
        if (sfxPool.Count == 0)
        {
            // OPTION 2 → return luôn (tắt tiếng khi quá tải)
            return;
        }

        AudioSource src = sfxPool.Dequeue();

        src.clip = s.clip;
        src.Play();

        StartCoroutine(ReturnToPool(src, s.clip.length));
    }

        private IEnumerator ReturnToPool(AudioSource src, float time)
        {
            yield return new WaitForSeconds(time);
            sfxPool.Enqueue(src);
        }
        public void StopBGM()
        {
            if(bgm == null || bgm.clip == null) return;

            bgm.Stop() ;
        }

        public void PlayBGM(string key)
        {
            SoundEntry s = database.sfxs.Find(x => x.key == key);
            if (s == null || s.clip == null || bgm == null) return;

            if (sfxPool.Count == 0)
            {
                // OPTION 2 → return luôn (tắt tiếng khi quá tải)
                return;
            }
            bgm.clip = s.clip;
            bgm.loop = true ;
            bgm.Play() ; 
        }
        public void PlayeLoopSFX(string key)
        {
            SoundEntry s = database.sfxs.Find(x => x.key == key);
            if (s == null || s.clip == null) return;

            // Nếu pool rỗng → tạo thêm hoặc return để tránh crash
            if (sfxPool.Count == 0)
            {
                // OPTION 2 → return luôn (tắt tiếng khi quá tải)
                return;
            }

            playling = sfxPool.Dequeue();

            playling.clip = s.clip;
            playling.loop = true ;
            playling.Play();
        }
        public void StopLoopSFX()
        {
            if(playling == null || playling.clip == null) return;

            playling.Stop() ;
            sfxPool.Enqueue(playling);
        }





        

    }

   