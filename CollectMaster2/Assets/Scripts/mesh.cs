

using UnityEngine;

public class FrontVertexManipulation : MonoBehaviour
{
    public float manipulationSpeed = 1f; // Manipülasyon hızı
    private MeshFilter meshFilter;
    private Vector3[] originalVertices;
    private bool isManipulating = false;

    void Start()
    {
        // MeshFilter bileşenini al
        meshFilter = GetComponent<MeshFilter>();

        // Mesh'in başlangıçtaki vertex pozisyonlarını kaydet
        originalVertices = meshFilter.mesh.vertices;
    }

    void Update()
    {
        // Sol tıklama algılama
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Fare tıklaması düzlemle temas ederse manipülasyonu başlat
            if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<Collider>())
            {
                isManipulating = true;
            }
        }

        // Sol tıklama bırakma algılama
        if (Input.GetMouseButtonUp(0))
        {
            isManipulating = false;
        }

        // Manipülasyon durumunda vertexleri hareket ettir
        if (isManipulating)
        {
            Vector3[] vertices = meshFilter.mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                // Sadece belirli bir sınırlık içindeki vertexleri manipüle et
                if (IsInFrontBoundary(vertices[i]))
                {
                    vertices[i] -= Vector3.up * manipulationSpeed * Time.deltaTime;
                }
            }

            // Vertex değişikliklerini uygula
            meshFilter.mesh.vertices = vertices;
            meshFilter.mesh.RecalculateBounds();
        }
    }

    // Belirli bir sınırlık içinde mi kontrol etmek için kullanılan yardımcı fonksiyon
    private bool IsInFrontBoundary(Vector3 vertex)
    {
        // Sadece objenizin önündeki vertexleri manipüle etmek için kullanılan sınırları burada belirleyebilirsiniz.
        // Örneğin, objenizin yerel 'z' pozisyonu 0'dan büyükse önündeki vertexleri içinde tutarız.
        return vertex.z > 0f;
    }
}

