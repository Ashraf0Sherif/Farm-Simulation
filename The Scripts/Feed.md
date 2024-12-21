# **1️⃣ What does this script do?**

This script allows the **sheep** to **grow in size** as it gets closer to a specific type of **feed plant**. As the distance between the sheep and the feed decreases, the sheep gradually grows.

---

# **2️⃣ Full Code Breakdown**

`using UnityEngine;`

`public class ScaleOnProximity : MonoBehaviour`  
`{`  
    `public string plantTag = "feed_plant"; // This is the tag of the plant the sheep interacts with`  
    `public float proximityThreshold = 5f; // The distance within which the sheep starts growing`  
    `public float scaleStep = 0.1f;📈// How much the sheep grows per step`  
    `public float scaleInterval = 1f;📉// Time between each growth step`  
    `public Animator sheepAnimator; // This controls animations on the sheep`

    `private Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f); // Initial size of the sheep`  
    `private Vector3 targetScale = new Vector3(1f, 1f, 1f); // Maximum size of the sheep`  
    `private Vector3 currentScale; // Keeps track of the current size of the sheep`  
    `private float timeSinceLastScale = 0f; // Used to keep track of time between growth`

    `void Start()`  
    `{`  
        `sheepAnimator = GetComponent<Animator>(); // Attach the Animator component to the sheep`  
        `currentScale = initialScale; // Set the initial size of the sheep`  
        `transform.localScale = currentScale; // Apply this size to the GameObject`  
    `}`

    `void Update()`  
    `{`  
        `// Find all the objects tagged as 'feed_plant'`  
        `GameObject[] plants = GameObject.FindGameObjectsWithTag(plantTag);`  
          
        `foreach (GameObject plant in plants)`  
        `{`  
            `// Calculate distance between the sheep and the plant`  
            `float distance = Vector3.Distance(transform.position, plant.transform.position);`

            `// If the distance is within the proximity threshold, grow the sheep`  
            `if (distance <= proximityThreshold)`  
            `{`  
                `if (timeSinceLastScale >= scaleInterval && currentScale.x < targetScale.x)`  
                `{`  
                    `currentScale += new Vector3(scaleStep, scaleStep, scaleStep); // Grow the sheep`  
                    `transform.localScale = currentScale; // Update the sheep's size`  
                    `timeSinceLastScale = 0f; // Reset the timer`  
                `}`  
            `}`  
        `}`

        `timeSinceLastScale += Time.deltaTime; // Track the time since the last growth step`  
    `}`  
`}`

---

# **3️⃣ Key Concepts (Default Unity Concepts)**

### **1\. MonoBehaviour**

* **What is it?**  
  * It is the **base class** for all scripts in Unity.  
  * It allows the use of methods like `Start()`, `Update()`, and `OnTriggerEnter()`.  
  * Without **MonoBehaviour**, you cannot attach the script to a **GameObject**.

### **2\. GameObject**

* **What is it?**  
  * Everything in the **Hierarchy** is a **GameObject**.  
  * It is a container for **components** like **Transform**, **Rigidbody**, and **Animator**.  
  * In this project, the **Sheep** and **FeedPlant** are GameObjects.

### **3\. Transform**

* **What is it?**  
  * Every GameObject in Unity has a **Transform**.  
  * It controls the **position, rotation, and scale** of the object.  
  * In this script, `transform.localScale` is used to change the sheep's **size**.

### **4\. Vector3**

* **What is it?**  
  * A **Vector3** represents a point or direction in 3D space (X, Y, Z).  
  * `transform.localScale` uses a **Vector3** to change the size of an object.

For example:  
`transform.localScale = new Vector3(1, 1, 1); // Normal size`

### **5\. Animator**

* **What is it?**  
  * The **Animator** controls animations, like running or eating.  
  * In this script, the **Animator** controls the sheep’s animations as it grows.

---

# **4️⃣ Step-by-Step Instructions (How to Build This in Unity)**

## **🔧 Step 1: Sheep (is prefab from the assets)**

1. **Optional**: Scale the sheep to **(0.5, 0.5, 0.5)** to match the script.  
2. **Attach the ScaleOnProximity script**  
   * Drag the **ScaleOnProximity.cs** file onto the **Sheep** GameObject in the **Hierarchy**.  
   * You'll see it appear in the **Inspector** under **ScaleOnProximity**.

---

## **🔧 Step 2: Create the Feed Plant**

1. **Tag the Feed Plant**  
   * Click the **FeedPlant**.  
   * At the top of the **Inspector**, click **Tag** → **Add Tag**.  
   * Create a new tag called **feed\_plant**.  
   * Select **FeedPlant** and assign the **feed\_plant** tag.

---

## **🔧 Step 3: Connect Components**

1. **Link the Animator**  
   * Select the **Sheep** GameObject.  
   * In the **Inspector**, link the **Animator** field of the **ScaleOnProximity** script to the **Sheep**'s **Animator** component.

---

# **5️⃣ How the Script Works**

1. Every frame, Unity calls `Update()`.  
2. It finds all GameObjects tagged as **feed\_plant**.  
3. It measures the distance from the **Sheep** to each plant.  
   * If the distance is **less than proximityThreshold (5)**, the sheep begins to grow.  
4. The size of the sheep is increased using **transform.localScale**.  
   * The size increase happens gradually, step-by-step, based on **scaleStep (0.1)**.  
5. The sheep stops growing when it reaches its **maximum size (1, 1, 1\)**.

---

# **6️⃣ Key Questions You Might Be Asked**

### **1\. What does MonoBehaviour do?**

* It allows scripts to be attached to **GameObjects**.  
* It provides access to Unity functions like **Start()**, **Update()**, and **OnTriggerEnter()**.

---

### **2\. How does the script detect when the sheep is near a feed plant?**

* It uses `GameObject.FindGameObjectsWithTag()` to find all GameObjects tagged as **feed\_plant**.  
* It calculates the distance using `Vector3.Distance()` between the sheep and each plant.  
* If the distance is less than **proximityThreshold**, the sheep starts growing.

---

### **3\. What happens if the sheep grows too big?**

* The script stops growing the sheep once it reaches the maximum size of **(1, 1, 1\)**.

---

### **4\. How can you modify the script so the sheep grows faster?**

* Increase **scaleStep** (this will make the sheep grow faster in each step).  
* Decrease **scaleInterval** (this will make the sheep grow more frequently).

---

### **5\. What happens if the FeedPlant does not have the correct tag?**

* The script won't detect the **FeedPlant**, so the sheep will not grow.  
* **Solution**: Make sure the **FeedPlant** has the tag **feed\_plant**.

