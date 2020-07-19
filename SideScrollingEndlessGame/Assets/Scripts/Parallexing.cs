using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallexing : MonoBehaviour
{
    Material mat;
    float offset;
    bool startParallexing;

    [SerializeField] float speed;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;

        GameManager.gameManager.OnGameplayStart += StartParallexing;
        GameManager.gameManager.OnGameplayEnd += StopParallexing;
    }

    private void Update()
    {
        if(startParallexing)
            Parallex();
    }

    void Parallex()
    {
        offset += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    void StartParallexing()
    {
        startParallexing = true;
    }

    void StopParallexing()
    {
        startParallexing = false;
    }

}
