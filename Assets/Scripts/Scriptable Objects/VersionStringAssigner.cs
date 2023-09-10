using UnityEngine;

public class VersionStringAssigner : MonoBehaviour
{
    public string versionString = "";

    // Start is called before the first frame update
    void Start()
    {
        versionString = "© GameJam Føroya 2023 " + Application.companyName.ToString() + " - Project: \"" + Application.productName.ToString() + "\" " + Application.version.ToString();

        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = versionString;
    }
}