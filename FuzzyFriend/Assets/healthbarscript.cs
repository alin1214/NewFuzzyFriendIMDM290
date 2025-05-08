using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private int maxHealth = 10;
    private int currentHealth;
    private float healthTimer = 0f;
    private float healthDecreaseInterval = 15f;

    public canvasmanager canvasManager;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    void Update()
    {
        healthTimer += Time.deltaTime;

        if (healthTimer >= healthDecreaseInterval)
        {
            healthTimer = 0f;
            currentHealth = Mathf.Max(currentHealth - 1, 0);
            slider.value = currentHealth;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetHealthBar();
        }
    }

    void ResetHealthBar()
    {
        slider.value = 10;
    }
}
