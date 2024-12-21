# **1️⃣ What does this script do?**

This script allows a **Harrow** to interact with **plants**. When the **Harrow** gets close to a plant, the plant is replaced with a **tomato bunch**. The tomato bunch is **interactable** — it can be grabbed, thrown, or picked up using Unity’s **XR interaction system**.

---

# **2️⃣ Full Code Breakdown**

`using UnityEngine;`  
`using UnityEngine.XR.Interaction.Toolkit; // Required for XR Interactable Components`

`public class PlantProximityManager : MonoBehaviour`  
`{`  
    `public GameObject harrow; // Reference to the Harrow object`  
    `public GameObject tomatoBunchPrefab; // Reference to the Tomato Bunch prefab`  
    `public float detectionRadius = 2.0f; // Distance at which the Harrow detects a plant`

    `void Update()`  
    `{`  
        **`// Find all objects with the "Plant" tag`**  
        `GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");`

        `foreach (GameObject plant in plants)`  
        `{`  
            **`// Check the distance between the Harrow and the Plant`**  
            `if (Vector3.Distance(harrow.transform.position, plant.transform.position) <= detectionRadius)`  
            `{`  
                `ReplaceWithTomatoBunch(plant);`  
            `}`  
        `}`  
    `}`

    `private void ReplaceWithTomatoBunch(GameObject plant)`  
    `{`  
        **`// Create a Tomato Bunch at the same position and rotation as the plant`**  
        `GameObject tomatoBunch = Instantiate(tomatoBunchPrefab, plant.transform.position, plant.transform.rotation);`  
          
        **`// Make the Tomato Bunch interactable with physics`**  
        `MakeInteractable(tomatoBunch);`  
          
        **`// Destroy the original plant`**  
        `Destroy(plant);`  
    `}`

    `private void MakeInteractable(GameObject tomatoBunch)`  
    `{`  
        **`// Ensure the object has a Collider (replace MeshCollider if necessary)`**  
        `Collider collider = tomatoBunch.GetComponent<Collider>();`  
        `if (collider == null || collider is MeshCollider)`  
        `{`  
            `if (collider != null) Destroy(collider); // Remove existing collider if it's a MeshCollider`  
            `tomatoBunch.AddComponent<BoxCollider>(); // Add a simple BoxCollider`  
        `}`

        **`// Add a Rigidbody for physics interaction`**  
        `Rigidbody rb = tomatoBunch.GetComponent<Rigidbody>();`  
        `if (rb == null)`  
        `{`  
            `rb = tomatoBunch.AddComponent<Rigidbody>();`  
        `}`  
        `rb.useGravity = true;`   
        `rb.isKinematic = false;` 

        **`// Add the XR Grab Interactable component`**  
        `XRGrabInteractable grabInteractable = tomatoBunch.GetComponent<XRGrabInteractable>();`  
        `if (grabInteractable == null)`  
        `{`  
            `grabInteractable = tomatoBunch.AddComponent<XRGrabInteractable>();`  
        `}`

        `grabInteractable.throwOnDetach = true;`   
        `grabInteractable.interactionLayerMask = LayerMask.GetMask("Default");`   
    `}`  
`}`

---

# **3️⃣ Key Concepts (Default Unity Concepts)**

### **1\. MonoBehaviour**

* **What is it?**  
  * It is the **base class** for all scripts in Unity.  
  * It allows the script to be attached to **GameObjects**.  
  * It gives access to Unity lifecycle methods like **Start()**, **Update()**, and **OnTriggerEnter()**.

---

### **2\. GameObject**

* **What is it?**  
  * A **GameObject** is a container for components like **Transform**, **Rigidbody**, and **Collider**.  
  * In this script, the **Harrow**, **Plant**, and **TomatoBunch** are GameObjects.

---

### **3\. Collider**

* **What is it?**  
  * A **Collider** defines the shape of an object for physical collisions.  
  * Here, a **BoxCollider** is used for the **TomatoBunch** to make it interactable.

---

### **4\. Rigidbody**

* **What is it?**  
  * A **Rigidbody** allows objects to be affected by gravity and physics.  
  * In this script, it is added to the **TomatoBunch** so it can fall, be picked up, and interact with other objects.

---

### **5\. XRGrabInteractable**

* **What is it?**  
  * It allows the **TomatoBunch** to be picked up, moved, and thrown in **VR or XR systems**.  
  * It makes the tomato interactive.

---

# **4️⃣ Step-by-Step Instructions (How to Build It in Unity)**

## **🔧 Attach the Script**

1. **Create the PlantProximityManager Script**  
   * Create an empty GameObject called **PlantProximityManager**.  
   * Attach the **ProximityHandler.cs** script to it.  
2. **Link the Components**  
   * Link the **Harrow** GameObject to the **Harrow** field in the script.  
   * Link the **TomatoBunch Prefab** to the **TomatoBunchPrefab** field in the script.

---

# **5️⃣ How the Script Works**

1. **Every frame**, Unity calls the `Update()` method.  
2. It finds all GameObjects with the tag **Plant**.  
3. It calculates the distance between the **Harrow** and each **Plant**.  
4. If the distance is **less than 2 units**, the script **destroys the plant** and **spawns a Tomato Bunch**.  
5. The Tomato Bunch is made interactable using:  
   * **Collider**: Added to the Tomato.  
   * **Rigidbody**: Makes the Tomato obey physics.  
   * **XRGrabInteractable**: Makes the Tomato grab-able.

---

# **6️⃣ Key Questions You Might Be Asked**

### **1\. What is MonoBehaviour, and why do we use it?**

* It allows a script to be attached to **GameObjects**.  
* It gives access to lifecycle methods like **Start()**, **Update()**, and **OnTriggerEnter()**.

---

### **2\. How does the script detect when the Harrow is near a plant?**

It calculates the distance between the **Harrow** and all objects tagged as **Plant** using:  
`Vector3.Distance(harrow.transform.position, plant.transform.position);`  
---

### **3\. How does the Tomato Bunch become interactable?**

* It adds a **BoxCollider** so the tomato can be touched.  
* It adds a **Rigidbody** so the tomato is affected by physics (gravity).  
* It adds an **XRGrabInteractable** so it can be picked up in VR.

---

### **4\. What would happen if the Plant tag was not assigned correctly?**

* The script would not be able to detect the plants.  
* **Solution**: Ensure the plant is tagged as **Plant**.

