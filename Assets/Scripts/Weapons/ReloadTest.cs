using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ReloadTest : MonoBehaviour
{
    [SerializeField]
    int ammoCount;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    float reloadDuration;
    [SerializeField]
    Slider reloadSlider;

    PlayerInput m_playerInput;
    bool m_playerInputHasBeenInit;
    int playerIndex;
    bool isControlSchemeKeyboardAndMouse;

    private float reloadFloatPerSecond;

    bool m_isReloading;

    InputAction m_reloadAction;


    private bool m_ReloadButtonIsBeingPressed;
    private bool m_ReleadActionPerformed;

    private void OnValidate()
    {
        reloadFloatPerSecond = 1.0f / reloadDuration;
    }

    public void OnReload(InputAction.CallbackContext callbackContext)
    {
        //Debug.Log("ReloadWasPressed!");
        Debug.Log($"Reload Event {callbackContext.phase}");
        switch(callbackContext.phase)
        {
            //THe Button was pressed
            case InputActionPhase.Started:
                m_ReloadButtonIsBeingPressed = true;
                break;
            // The Action has met all preformed Conditions
            case InputActionPhase.Performed:
                m_ReleadActionPerformed = true;
                break;
            // The Button was released
            case InputActionPhase.Canceled:
                m_ReloadButtonIsBeingPressed = false;
                m_ReleadActionPerformed = false;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_playerInput = gameObject.GetComponent<PlayerInput>();
        m_isReloading = false;

        if (m_playerInput != null)
        {
            playerIndex = m_playerInput.playerIndex;
            Debug.Log($"Player#{playerIndex}'s currentControlScheme is {m_playerInput.currentControlScheme}");

            
            if (m_playerInput.currentControlScheme == "Keyboard&Mouse")
            {
                isControlSchemeKeyboardAndMouse = true;
                m_reloadAction = m_playerInput.actions["Reload"];
            }
        }
        // Skurðkota END
    }

    private void OnDisable()
    {
        m_playerInput.actions["Reload"].performed -= OnReload;
        m_playerInput.actions["Reload"].started -= OnReload;
        m_playerInput.actions["Reload"].canceled -= OnReload;

        m_playerInputHasBeenInit = false;
    }

    private void InitPlayerInput()
    {
        if (!m_playerInput.isActiveAndEnabled) return;

        m_playerInputHasBeenInit = true;

        m_playerInput.actions["Reload"].performed += OnReload;
        m_playerInput.actions["Reload"].started += OnReload;
        m_playerInput.actions["Reload"].canceled += OnReload;
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_playerInputHasBeenInit)
        {
            InitPlayerInput();
        }

        if(m_reloadAction.triggered == true)
        {
            Debug.Log("Trigger This!");
        }
    }

    //    public void OnReloading() => m_isReloading = m_reloadAction.ReadValue<float>();
    //public void OnReloading() => m_isReloading = m_reloadAction.WasPressedThisFrame();

}
