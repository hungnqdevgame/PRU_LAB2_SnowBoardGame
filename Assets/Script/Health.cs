using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] GameObject[] hearts; // Array to hold heart GameObjects
    public int GetHeath() => health; // Getter for health
    public void SetHeath(int h) => health += h;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health);
        }
    }

    public void ResetHealth()
    {
      
    }
}
