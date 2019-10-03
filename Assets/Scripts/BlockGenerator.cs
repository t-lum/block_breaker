using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] blocks;
    public int lines;

    // Start is called before the first frame update
    void Start()
    {
        CreateBlockGroup();
    }

    void CreateBlockGroup()
    {
        Bounds blockLimits = blocks[0].GetComponent<SpriteRenderer>().bounds;
        float blockWidth = blockLimits.size.x;
        float blockHeight = blockLimits.size.y;

        CollectInfo(
            blockWidth,
            out float screenWidth,
            out float screenHeight,
            out float widthMultiplier,
            out int columns);

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject randomBlock = blocks[Random.Range(0, blocks.Length)];
                GameObject instacedBlock = Instantiate(randomBlock);

                instacedBlock.transform.position = new Vector3(
                    -(screenWidth * 0.5f) + (j * blockWidth * widthMultiplier),
                    (screenHeight * 0.5f) - (i * blockHeight),
                    0);

                float newBlockWidth = instacedBlock.transform.localScale.x * widthMultiplier;

                instacedBlock.transform.localScale = new Vector3(
                    newBlockWidth,
                    instacedBlock.transform.localScale.y,
                    0);
            }
        }
    }

    void CollectInfo(
        float blockWidth,
        out float screenWidth,
        out float screenHeight,
        out float widthMultiplier,
        out int columns)
    {
        Camera camera = Camera.main;

        screenWidth =
            (camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0))
            - camera.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;

        screenHeight =
            (camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0))
            - camera.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;

        columns = (int)(screenWidth / blockWidth);

        widthMultiplier = screenWidth / (columns * blockWidth);
    }
}
