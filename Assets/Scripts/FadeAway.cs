using UnityEngine;
using UnityEngine.Events;

public class FadeAway : MonoBehaviour
{
    public float fadeTime;
    public float randomFadeTimeMin;
    public float randomFadeTimeMax;
    public bool useRandomFadeTime;
    public bool isFading;
    public bool destroySelfWhenFadeEnds;
    public bool hasAlreadyInvokedFadeEvent;
    public bool sulfuricDissolve;
    public bool allowedToResetSulfuriceDissolve;
    public SpriteRenderer[] sprites;
    public GameObject[] musicToDisable;
    public GameObject moneyMaker;
    public UnityEvent fullyFaded;
    public AudioSource musicToPlay;
    public AudioSource resetSound;
    public AudioSource startFadeSound;
    private GameObject moneyMakerInstance;

    float fadeProgress;
    // Start is called before the first frame update
    void Start()
    {
        if (useRandomFadeTime) fadeTime = Random.Range(randomFadeTimeMin, randomFadeTimeMax);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            //Increase fadeProgress by the time if it is less than 1
            if (fadeProgress <= 1)
            {
                fadeProgress += (Time.deltaTime / fadeTime);
            }
            //If fadeProgress is at least one, cap it at one then send the fullyFaded event
            if (fadeProgress >= 1)
            {
                fadeProgress = 1;

                if (!hasAlreadyInvokedFadeEvent)
                {
                    fullyFaded.Invoke();
                    hasAlreadyInvokedFadeEvent = true;
                }
                if (destroySelfWhenFadeEnds) Destroy(gameObject);
            }
            UpdateAllSpriteColors();
        }
    }

    public void DamageObject(float damage)
    {
        if (!isFading)
        {
            isFading = true;
            if (startFadeSound) startFadeSound.Play();
            if (musicToPlay) musicToPlay.Play();
            if (moneyMaker)
            {
                moneyMakerInstance = Instantiate(moneyMaker);
                moneyMakerInstance.transform.position = transform.position;
            }
            foreach (GameObject music in musicToDisable)
            {
                music.SetActive(false);
            }
        }
        else
        {
            fadeProgress += damage / fadeTime;
            if ((fadeTime - fadeProgress * fadeTime >= damage) && musicToPlay) musicToPlay.time += damage;
            if (moneyMakerInstance) moneyMakerInstance.GetComponent<AreaParent>().DesiredChildCount++;
        }
    }

    public void ResetFading()
    {
        fadeProgress = 0f;
        isFading = false;
        UpdateAllSpriteColors();
        hasAlreadyInvokedFadeEvent = false;
        if (resetSound) resetSound.Play();
        if (musicToPlay)
        {
            musicToPlay.Stop();
            musicToPlay.time = 0;
        }
        foreach (GameObject music in musicToDisable)
        {
            music.SetActive(true);
        }
        if (moneyMakerInstance) Destroy(moneyMakerInstance);
    }

    public void UpdateAllSpriteColors()
    {
        foreach (SpriteRenderer sprite in sprites)
        {
            Color colorWithTransparency = sprite.color;
            colorWithTransparency.a = 1f - fadeProgress;
            sprite.color = colorWithTransparency;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CancelInvoke();
        if (collision.CompareTag("Sulfuric Water"))
        {
            DamageObject(1.22f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (allowedToResetSulfuriceDissolve && collision.CompareTag("Sulfuric Water")) Invoke("ResetFading", 0.9f);
    }
}
