# Capabilities-Assessment #

# **Zutari Unity Developer Interview Task** #

## Task 1

The system can be broken up into several different parts as briefly described below: 

- ### Changing Scenes

This implementation is pretty straight forward, simply adding a method to a Button OnClick to transition between scenes using Unity's Scene Manager.

- ### Speed Controller

Basic implemenation of iterating through a list of speeds when the "C" key is pressed. 

- ### Cube Movement, Color Change, Boundary Wrapper

For these functionalities a simple Finite State Machine (FSM) was implemented. A FSM is a model that can be used to control execution flow. In this scenario, the FSM is made up of 5 states, that is: 
- Idle
- Move Left
- Move Right
- Move Up 
- Move Down

Each state represents a specific behaviour of the cube. Generally speaking, FSMs are a nice way of decoupling behaviours to better organise the project. The states themselves have 3 important points:

| Method        | Description                                                  |
|---------------|--------------------------------------------------------------|
| Enter()       | Initialization process when transitioning to the state       |
| UpdateLogic() | Logic that runs continuously when state is current           |
| Exit()        | Any clean-ups or unsubscribe events before leaving the state |

As such, the colour changes were implemented within the Enter() method. This was done by setting the material of the cube to a different colour.

#### Input system
For the actual input system, I used Unity's Input Manager which allows for use of arrows and wasd keys.

Eg.

``` Input.GetAxis("Vertical") ```

This above returns a float. If negative it means down and vice versa. Therefore, state changes can be implemented comparing these to zero or epsilson. Every moving state transitions back to Idle (zero motion) before moving to another. 

When receiving this value, it is multiplied by the chosen speed and applied onto the rigidbody to make it move. Usually this would be implemented in UpdateLogic() but used an UpdatePhysics() method that is called in LateUpdate(). Usually physics related tasks should be implemented in FixedUpdate, however, the physics needed to be performed after logic related tasks if there is to be a change in state. 

#### Boundary Wrapper
For the boundary wrapper, boundaries were determined using the camera position. Once determined, each boundary was related to one state (i.e. if moving right you can only hit the right boundary). Therefore, a conditional statement was executed in the state and if the boundary was hit, the position of the cube of that axis movement was multiplied by negative one (-1) hence the cube will move to the opposite side. I used a conditional, however, a collider could have worked just as well. 


## Task 2

The implementation can be put simply as pulling data from an API, deserializing the data, and displaying it. 

Using ```HttpWebRequest``` a call was created to pull relevant data from the API by specifying a city. Once a response is received, the data is deserialized using ```NewtonSoft.JsonConvert``` and a C# data model is returned relevant to the json properties. The data model consists of 3 properties, that being: 

- Name of the city
- Another model *Main* which contains the current temperature
- Another model *Weather* which contains the description of the weather

Once the data model is assigned, I created a prefab as template to use for display. Finally, on start of the program, the template was instantiated and the data model was applied on the relevant text fields for display. 

