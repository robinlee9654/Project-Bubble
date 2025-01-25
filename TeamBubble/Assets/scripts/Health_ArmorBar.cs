using UnityEngine;
using UnityEngine.UI;

public class Health_ArmorBar : MonoBehaviour
{
    //[SerializeField] private health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private Image armorBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        // if playerarmor = 0 then armorbar.fillamount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
