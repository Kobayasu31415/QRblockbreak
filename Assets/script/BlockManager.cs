using UnityEngine;

class BlockManager : MonoBehaviour
{
    [SerializeField]
    string m_url;

    [SerializeField]
    Block m_blockPrefab;

    [SerializeField]
    GameObject m_kinematicblockPrefab;

    Texture2D m_QRTexture;

    [SerializeField]
    QRcodeGenerator m_QRcodeGenerator;

    Vector3 m_blockPosition;
    Color32 pixcelColor;

    int m_QRmargin = 4;

    float m_blocksize= 0.14f;

    void Start()
    {
        m_QRTexture = m_QRcodeGenerator.Generate(37,37,m_url);
        GenerateBlock();
    }

    void GenerateBlock()
    {
        int width = m_QRTexture.width;
        int height = m_QRTexture.height;
        for(int i=m_QRmargin; i <width-m_QRmargin; i++)
        {
            for(int j=m_QRmargin; j < height-m_QRmargin; j++)
            {
                m_blockPosition.x = m_blocksize*i - 2.5f;
                m_blockPosition.y = m_blocksize*j;
                m_blockPosition.z = transform.position.z;

                pixcelColor = m_QRTexture.GetPixel(i, j);

                if(pixcelColor.r == 0)
                {
                    CreateKinematicBlock(m_blockPosition);
                }
                else{
                    CreateBlock(m_blockPosition);
                }
            }
        }
    }

    void CreateBlock(Vector3 position)
    {
        var block = Instantiate(m_blockPrefab, position, transform.rotation);
    }

    void CreateKinematicBlock(Vector3 position)
    {
        var kinematicblock = Instantiate(m_kinematicblockPrefab, position, transform.rotation);
    }

}