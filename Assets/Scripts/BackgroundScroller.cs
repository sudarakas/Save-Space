using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField]
    float backgroundScrollSpeed = 0.5f;
    Material myMatrial;
    Vector2 offSet;

    // Use this for initialization
    void Start()
    {
        myMatrial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMatrial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
