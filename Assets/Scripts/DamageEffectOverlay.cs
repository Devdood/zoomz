using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectOverlay : MonoBehaviour
{
    [SerializeField]
    private Character target;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [Header("Alpha hit values")]
    [SerializeField]
    private float decreaseSpeed = 1;

    [SerializeField]
    private float singleHitAlphaIncrease = 0.15f;
    
    private Coroutine alphaCoroutine;

    private void Awake()
    {
        target.OnDamage += Target_OnDamage;
    }

    private void Target_OnDamage(Character target)
    {
        if(alphaCoroutine != null)
        {
            StopCoroutine(alphaCoroutine);
        }

        alphaCoroutine = StartCoroutine(ShowAlpha());
    }

    private IEnumerator ShowAlpha()
    {
        canvasGroup.alpha += singleHitAlphaIncrease;

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * decreaseSpeed;
            yield return 0;
        }
    }
}
