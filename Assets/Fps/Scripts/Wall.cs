using UnityEngine;

public class Wall : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public Transform brickPrefab;

    void Start()
    {
        GenerateWall();
    }

    private void GenerateWall()
    {
        for(int j = 0; j < height; j++) {
            for (int i = 0; i < width; i++)
            {
                var brck = Instantiate(brickPrefab, transform);
                brck.localPosition = new Vector3(
                    -width/2 + i + (j%2==0 ? 0.5f : 0),
                    0.5f + j,
                    0f
                );
            }
        }
    }
}
