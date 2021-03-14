using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealtManager : MonoBehaviour
{
    
    public int maxHealth;
    public int currentHealth;
    /*public Vector2 StartPosition;*/

    /*public bool flashActive;
    public float flashLength;
    private float flashCounter;*/

    private SpriteRenderer characterRenderer;
   

    public RectTransform HudMenu;
    public RectTransform GameOverMenu;
    /*public RectTransform Joystick;*/
    private PlayerControler _controler;
    private Animator _animator;


    public GameObject particulasMuerte;
    private SFXSoundManager SFXSoundManager;
    public AudioSource _pasos;
    /*public ScoreScript ScoreScript;*/
  






    private void Awake()
    {
        
        _pasos = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _controler = GetComponent<PlayerControler>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        currentHealth = maxHealth;

        SFXSoundManager = FindObjectOfType<SFXSoundManager>();

    }

   
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(particulasMuerte, gameObject.transform.position, gameObject.transform.rotation);
            SFXSoundManager.GameOver.Play();
            gameObject.SetActive(false);
           

   


}
        
        /*
            if (flashActive)
            {
           
            flashCounter -= Time.deltaTime;
            
            if (flashCounter > flashLength * 0.66f)
                {
                    ToggleColor(false);
                }else if (flashCounter > flashLength * 0.33f)
                {
                    ToggleColor(true);
                }else if (flashCounter > 0)
                {
                    ToggleColor(false);
                }
                else
                {
                    ToggleColor(true);
                    flashActive = false;
                }
            }

        */

        
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(Visual());

    /*if (flashLength > 0)
    {
        flashActive = true;
        flashCounter = flashLength;
    }*/
}

    public void UpdateMaxHealt(int newMaxHealt)
    {
        maxHealth = newMaxHealt;
        currentHealth = maxHealth;
    }

    /* private void ToggleColor(bool visible)
     {


         characterRenderer.color = new Color(characterRenderer.color.r,
             characterRenderer.color.g, characterRenderer.color.b, (visible ? 1.0f : 0.0f));
     }*/

   

    private void OnDisable()
    {
       
  

        HudMenu.gameObject.SetActive(false);
        GameOverMenu.gameObject.SetActive(true);
        
        _animator.enabled = false;
        _controler.enabled = false;
        SFXSoundManager.enabled = false;
        _pasos.enabled = false;
        


    }

    private void OnEnable()
    {
        
       
        /*ScoreScript.scoreValue = 0;*/
        characterRenderer.color = Color.white;
        currentHealth = 30;
        GameOverMenu.gameObject.SetActive(false);
       
        /*MenuGame.gameObject.SetActive(true);*/
       // gameObject.transform.position = new Vector3(-13.33f, 6.794f, 0.0f);
        


    }

    private IEnumerator Visual()
    {
        characterRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        characterRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        characterRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        characterRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }



}
