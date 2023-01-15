using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLazer : Ability
{
    
    private bool isRdy;
    private float cooldownTimer = 0;
    private float maxCooldown = 10f;
    private float beamTimer = 0;
    private int maxLevel = 2;
    private int currentLevel = 0;

    [SerializeField] GameObject boxLeft;
    [SerializeField] GameObject boxRight;
    [SerializeField] LineRenderer rendoRight;
    [SerializeField] LineRenderer rendoLeft;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    [SerializeField] private Image _timerSprite;

    public int getMaxlvl()
    {
        return maxLevel;
    }

    public int getCurrentLvl()
    {
        return currentLevel;
    }
    public void lvlUp()
    {
        currentLevel++;
    }
    public override string getName()
    {
        
        return "laser";
    }

    public void setMaxCooldown(float maxCooldown)
    {
        this.maxCooldown = maxCooldown;
    }
    
    public float getMaxCooldown()
    {
        return this.maxCooldown;
    }

    public override bool isReady()
    {
        return isRdy;
    }

    public override void use()
    {
        if (boxLeft.activeSelf == true)
        {
            boxLeft.SetActive(false);
            boxRight.SetActive(false);
        }
        
        if (!isRdy) return;
        //print("lazer used");
        //beam(gameObject.transform.position, gameObject.transform.forward, 5f);
        rendoLeft.enabled = true;
        rendoRight.enabled = true;

        //print("lazer after enabled");
        isRdy = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRdy = true;
        _timerSprite.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRdy == false)
        {
            cooldownTimer += Time.deltaTime * (1 / Time.timeScale);
            _timerSprite.fillAmount = 1 - (cooldownTimer / maxCooldown);
        }
        if (cooldownTimer > 10)
        {
            isRdy = true;
            cooldownTimer = 0;
            _timerSprite.fillAmount = cooldownTimer;
        }

        if (rendoRight.enabled == true && rendoLeft.enabled == true)
        {
            beamTimer += Time.deltaTime * (1 / Time.timeScale);
        }
        if (beamTimer > 5)
        {
            rendoRight.enabled = false;
            beamTimer = 0;
            rendoLeft.enabled = false;
            
            boxLeft.SetActive(true);
            boxRight.SetActive(true);
        }

        beam(left.position, left.forward, 5f, rendoLeft);
        beam(right.position, right.forward, 5f, rendoRight);
    }

    void beam(Vector3 targetPos, Vector3 direction, float length, LineRenderer rendo)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if (Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            endPos = rayHit.point;
            //Debug.Log(rayHit.collider.gameObject.name);
        }
        
        rendo.SetPosition(0, targetPos);
        rendo.SetPosition(1, endPos);
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
