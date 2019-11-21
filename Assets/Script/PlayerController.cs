using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 8;
    public GameObject collectible;
    public GameObject enemy;
    public Text countText;
    public Text livesText;
    public Text finalText;
    public GameObject postProcessGameObject;
    public GameObject fireworks;

    //private PostProcessVolume ppVolume;
    private int lives;
    private int count;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        setCountText();

        lives = 15;
        setLivesText();

        for (int i = 0; i <= 5; i++)
        {
            createNewCollectible();
        }

        for(int i = 0; i < 2; i++)
        {
            createNewEnemy();
        }

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            createNewCollectible();

            count++;
            setCountText();

            if(count >= 20)
            {
                finalText.text = "You win!";
                removeAllObjecta();
            }
        }
    }

    void createNewCollectible()
    {
        Vector3 vector = new Vector3(Random.Range(-4.0f, 4.0f), 0.42f, Random.Range(-4.0f, 4.0f));
        Instantiate(collectible, vector, Quaternion.identity);
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void setLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    void createNewEnemy()
    {
        Vector3 vector = new Vector3(Random.Range(-4.0f, 4.0f), 0.35f, Random.Range(-4.0f, 4.0f));
        Instantiate(enemy, vector, Quaternion.identity);
    }

    void removeAllObjecta()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject ob in allObjects)
        {
            if((ob.CompareTag("Pick Up")) || (ob.CompareTag("Enemy")))
            {
                Destroy(ob);
            }
        }
        //BlurAtRuntime();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            setLivesText();
            if (lives <= 0)
            {
                finalText.text = "Game Over :(";
                removeAllObjecta();
            }
        }
    }

    /*void BlurAtRuntime()
    {
        DepthOfField depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        depthOfField.active = true;
        depthOfField.enabled.Override(true);
        depthOfField.aperture.Override(20.0f);
        depthOfField.focalLength.Override(65.0f);
        depthOfField.focusDistance.Override(1.0f);
        ppVolume = postProcessGameObject.GetComponent<PostProcessVolume>();
        ppVolume = PostProcessManager.instance.QuickVolume(postProcessGameObject.layer, 0f, depthOfField);
    }

    private void OnDestroy()
    {
        if (ppVolume != null)
        {
            RuntimeUtilities.DestroyVolume(ppVolume, true, true);
        }
    }*/





}
