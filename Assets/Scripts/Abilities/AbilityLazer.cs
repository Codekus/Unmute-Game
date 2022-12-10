using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLazer : Ability
{
    
    private bool isRdy;
    private float cooldownTimer = 0;
    private float beamTimer = 0;

    [SerializeField] LineRenderer rendo;

    [SerializeField] private Image _timerSprite;
    public override string getName()
    {
        
        return "laser";
    }

    public override bool isReady()
    {
        return isRdy;
    }

    public override void use()
    {
        if (!isRdy) return;
        print("lazer used");
        //beam(gameObject.transform.position, gameObject.transform.forward, 5f);
        rendo.enabled = true;
        
        
        isRdy = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRdy = true;
        _timerSprite.fillAmount = 0;

        rendo = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRdy == false)
        {
            cooldownTimer += Time.deltaTime * (1 / Time.timeScale);
            _timerSprite.fillAmount = 1 - (cooldownTimer / 15);
        }
        if (cooldownTimer > 10)
        {
            isRdy = true;
            cooldownTimer = 0;
            _timerSprite.fillAmount = cooldownTimer;
        }

        if (rendo.enabled == true)
        {
            beamTimer += Time.deltaTime * (1 / Time.timeScale);
        }
        if (beamTimer > 5)
        {
            rendo.enabled = false;
            beamTimer = 0;
            
        }
        beam(gameObject.transform.position, gameObject.transform.forward, 5f);
    }

    void beam(Vector3 targetPos, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if (Physics.Raycast(ray, out RaycastHit rayHit, length))
        {
            endPos = rayHit.point;
            Debug.Log(rayHit.collider.gameObject.name);
        }
        
        rendo.SetPosition(0, targetPos);
        rendo.SetPosition(1, endPos);
    }
}
