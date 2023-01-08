using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform head;
    public Transform feet;
    private float _maxHealth = 20f;
    private float currentHealth;
    [SerializeField] private Healthbar _healthbar;

    void Start() 
    {
        currentHealth = _maxHealth;
        
        _healthbar.updateHealthbar(_maxHealth, currentHealth);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            currentHealth -= 1f;
            _healthbar.updateHealthbar(currentHealth, _maxHealth);
            if (currentHealth <= 0)
            {
                _healthbar.onDeath();
            }
            print(currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, head.position.y-1, head.position.z);
        //gameObject.transform.rotation = new Quaternion(head.rotation.x, head.rotation.y, head.rotation.z, 0);
    }

    public void Heal()
    {
        currentHealth += 5f;
        if (currentHealth > _maxHealth)
        {
            currentHealth = _maxHealth;
        }
        _healthbar.updateHealthbar(currentHealth, _maxHealth);
    }
    
    
}
