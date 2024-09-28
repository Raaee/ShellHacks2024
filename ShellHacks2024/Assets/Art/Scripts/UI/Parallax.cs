using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private float singleTextureWidth;

    void Start() {
        SetUpTexture();
    }
    void Update() {
        CheckReset();
        Scroll();
    }
    private void SetUpTexture() {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }
    private void Scroll() {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }
    private void CheckReset() {
        if ((Mathf.Abs(transform.position.x) - singleTextureWidth) > 0) {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
}
