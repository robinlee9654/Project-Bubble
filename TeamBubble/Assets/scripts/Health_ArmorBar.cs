using UnityEngine;
using UnityEngine.UI;

public class Health_ArmorBar : MonoBehaviour
{
    [SerializeField] private PlayerStats playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private Image armorBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalhealthBar.fillAmount = 1;
        armorBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // if playerarmor = 0 then armorbar.fillamount = 0;
        if(playerHealth.maxArmor == 0) //show the hp
        {
            currentHealthBar.fillAmount =  0.1f + playerHealth.maxStamina * 0.009f;
            armorBar.fillAmount = 0;
        }
        else //armor still exists
        {
            armorBar.fillAmount = 0.1f + playerHealth.maxArmor * 0.009f;
        }
            
    }
}
