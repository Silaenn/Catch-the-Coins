using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] backgrounds;

    private float backgroundSpeed = 2f;

    private bool isScrolling = true;
    private float[] backgroundHeights;

    private void Start() {
        backgroundHeights = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++){
            backgroundHeights[i] = backgrounds[i].GetComponent<SpriteRenderer>().bounds.size.y;
        }
    }

    void Update()
    {
        Scroll();
    }

    void Scroll(){
        if(isScrolling){
            for (int i = 0; i < backgrounds.Length; i++){
                backgrounds[i].transform.Translate(Vector3.down * backgroundSpeed * Time.deltaTime);

                if(backgrounds[i].transform.position.y <= -backgroundHeights[i]){
                    Vector3 resetPosition = new Vector3(backgrounds[i].transform.position.x, backgrounds[i].transform.position.y + backgroundHeights[i] * 2, backgrounds[i].transform.position.z);
                    backgrounds[i].transform.position = resetPosition;
                }
            }
        }
    }
}
