using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class AbilityLazer : Ability
{
    
    private bool isRdy;
    private float cooldownTimer = 0;
    private float maxCooldown = 14f;
    private float beamTimer = 5;
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
        
        if (!isRdy) return;

        beamTimer = 0;
        if (boxLeft.activeSelf == true)
        {
            boxLeft.SetActive(false);
            boxRight.SetActive(false);
        }
      
        rendoLeft.enabled = true;
        rendoRight.enabled = true;
        
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
        if (cooldownTimer > maxCooldown)
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
            beamTimer = 5;
            rendoLeft.enabled = false;
            
            boxLeft.SetActive(true);
            boxRight.SetActive(true);
        }
        else if (beamTimer < 5)
        {
            beam(left.position, left.forward, 20f, rendoLeft);
            beam(right.position, right.forward, 20f, rendoRight);
        }

        
        
    }

    void beam(Vector3 targetPos, Vector3 direction, float length, LineRenderer rendo)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if (Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            endPos = rayHit.point;

            if (rayHit.collider.tag.Equals("Enemy"))
            {
                print("lasered");
                GameState.ememieDestoyed();
                Destroy(rayHit.collider.gameObject);
            }
            
        }
        
        rendo.SetPosition(0, targetPos);
        rendo.SetPosition(1, endPos);
    }
}
