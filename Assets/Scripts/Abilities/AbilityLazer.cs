using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLazer : Ability
{
    
    private bool isRdy;
    private float timer = 0;

    private LineRenderer rendo;

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
        beam(transform.position, transform.forward, 5f);
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
            timer += Time.deltaTime * (1 / Time.timeScale);
            _timerSprite.fillAmount = 1 - (timer / 15);
        }
        if (timer > 10)
        {
            isRdy = true;
            timer = 0;
            _timerSprite.fillAmount = timer;
        }
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
