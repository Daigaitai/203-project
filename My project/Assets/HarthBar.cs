using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private GameObject player;
    private HeroKnight heroKnight;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("HeroKnight");
        heroKnight = player.GetComponent<HeroKnight>();
        SetMaxHealth(heroKnight.maxHealth);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        SetHealth(heroKnight.currentHealth);
    }
}
