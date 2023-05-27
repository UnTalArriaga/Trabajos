/*---------------------------------------------------------*/
/* ----------------   Práctica 3 --------------------------*/
/*-----------------    2023-1   ---------------------------*/
/*-------Alumno: Arriaga Mejía José Carlos --------------*/
/*-------Cuenta: 316017862 ------------------*/
#include <glew.h>
#include <glfw3.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <shader_m.h>

#include <iostream>

void resize(GLFWwindow* window, int width, int height);
void my_input(GLFWwindow *window);

// settings
// Window size
int SCR_WIDTH = 3800;
int SCR_HEIGHT = 7600;

GLFWmonitor *monitors;
GLuint VBO[2], VAO[2], EBO[2];

void myData(void);
void getResolution(void);

//For Keyboard
//Declaramos las variables para la traslaci[on linea 227 aprox, pero se recomienda que sea a través del teclado, linea 271 aprox
float MovX = -10.0f,
	  MovY = -10.0f,
	  MovZ = -30.0f;//Lo modificamos de 0 a -5 para evitar salir pegado en la proyección de perspectiva


void getResolution()
{
	const GLFWvidmode * mode = glfwGetVideoMode(glfwGetPrimaryMonitor());

	SCR_WIDTH = mode->width;
	SCR_HEIGHT = (mode->height) - 80;
}

void myData()
{	

	GLfloat verticesCubo[] = {
		//Position				//Color
		-0.5f, -0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V0 - Frontal
		0.5f, -0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V1
		0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V5
		-0.5f, -0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V0
		-0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V4
		0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 0.0f,	//V5

		0.5f, -0.5f, -0.5f,		1.0f, 1.0f, 0.0f,	//V2 - Trasera
		-0.5f, -0.5f, -0.5f,	1.0f, 1.0f, 0.0f,	//V3
		-0.5f, 0.5f, -0.5f,		1.0f, 1.0f, 0.0f,	//V7
		0.5f, -0.5f, -0.5f,		1.0f, 1.0f, 0.0f,	//V2
		0.5f, 0.5f, -0.5f,		1.0f, 1.0f, 0.0f,	//V6
		-0.5f, 0.5f, -0.5f,		1.0f, 1.0f, 0.0f,	//V7

		-0.5f, 0.5f, 0.5f,		0.0f, 0.0f, 1.0f,	//V4 - Izq
		-0.5f, 0.5f, -0.5f,		0.0f, 0.0f, 1.0f,	//V7
		-0.5f, -0.5f, -0.5f,	0.0f, 0.0f, 1.0f,	//V3
		-0.5f, -0.5f, -0.5f,	0.0f, 0.0f, 1.0f,	//V3
		-0.5f, 0.5f, 0.5f,		0.0f, 0.0f, 1.0f,	//V4
		-0.5f, -0.5f, 0.5f,		0.0f, 0.0f, 1.0f,	//V0

		0.5f, 0.5f, 0.5f,		0.0f, 1.0f, 0.0f,	//V5 - Der
		0.5f, -0.5f, 0.5f,		0.0f, 1.0f, 0.0f,	//V1
		0.5f, -0.5f, -0.5f,		0.0f, 1.0f, 0.0f,	//V2
		0.5f, 0.5f, 0.5f,		0.0f, 1.0f, 0.0f,	//V5
		0.5f, 0.5f, -0.5f,		0.0f, 1.0f, 0.0f,	//V6
		0.5f, -0.5f, -0.5f,		0.0f, 1.0f, 0.0f,	//V2

		-0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 1.0f,	//V4 - Sup
		0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 1.0f,	//V5
		0.5f, 0.5f, -0.5f,		1.0f, 0.0f, 1.0f,	//V6
		-0.5f, 0.5f, 0.5f,		1.0f, 0.0f, 1.0f,	//V4
		-0.5f, 0.5f, -0.5f,		1.0f, 0.0f, 1.0f,	//V7
		0.5f, 0.5f, -0.5f,		1.0f, 0.0f, 1.0f,	//V6

		-0.5f, -0.5f, 0.5f,		1.0f, 1.0f, 1.0f,	//V0 - Inf
		-0.5f, -0.5f, -0.5f,	1.0f, 1.0f, 1.0f,	//V3
		0.5f, -0.5f, -0.5f,		1.0f, 1.0f, 1.0f,	//V2
		-0.5f, -0.5f, 0.5f,		1.0f, 1.0f, 1.0f,	//V0
		0.5f, -0.5f, -0.5f,		1.0f, 1.0f, 1.0f,	//V2
		0.5f, -0.5f, 0.5f,		1.0f, 1.0f, 1.0f,	//V1
	};

	//Arreglo para la letra C
	GLfloat verticesLuis[] = {
		// positions			//Color
		-0.5f, 0.7f, -0.5f,		1.0f, 0.0f, 0.0f,	//V0
		0.5f, 0.7f, -0.5f,		1.0f, 0.0f, 1.0f,	//V1
		0.5f, 0.3f, -0.5f,		1.0f, 1.0f, 1.0f,	//V2
		-0.2f, 0.3f, -0.5f,		1.0f, 1.0f, 0.0f,	//V3
		-0.2f, -0.3f, -0.5f,	0.0f, 1.0f, 0.0f,	//V4
		0.5f, -0.3f, -0.5f,		0.0f, 1.0f, 1.0f,	//V5
		0.5f, -0.7f, -0.5f,		0.0f, 0.0f, 1.0f,	//V6
		-0.5f, -0.7f, -0.5f,	1.0f, 1.0f, 1.0f,	//V7
	};

	unsigned int indicesLuis[] =
	{
		0, 1, 2, 3, 4, 5, 6, 7
	};

	glGenVertexArrays(2, VAO);
	glGenBuffers(2, VBO);
	glGenBuffers(2, EBO);	//Only if we are going to work with index


	glBindVertexArray(VAO[0]);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[0]);
	glBufferData(GL_ARRAY_BUFFER, sizeof(verticesCubo), verticesCubo, GL_STATIC_DRAW);

	// position attribute
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)0);
	glEnableVertexAttribArray(0);
	// color attribute
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)(3 * sizeof(float)));
	glEnableVertexAttribArray(1);

	//Para trabajar con indices (Element Buffer Object)
	//glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[0]);
	//glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);


	glBindVertexArray(VAO[1]);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[1]);
	glBufferData(GL_ARRAY_BUFFER, sizeof(verticesLuis), verticesLuis, GL_STATIC_DRAW);

	// position attribute
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)0);
	glEnableVertexAttribArray(0);
	// color attribute
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)(3 * sizeof(float)));
	glEnableVertexAttribArray(1);

	//Para trabajar con indices (Element Buffer Object)
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[1]);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indicesLuis), indicesLuis, GL_STATIC_DRAW);

	glBindBuffer(GL_ARRAY_BUFFER, 0);

	glBindVertexArray(0);
}


int main()
{
    // glfw: initialize and configure
    // ------------------------------
    glfwInit();
    /*glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);*/

#ifdef __APPLE__
    glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE); // uncomment this statement to fix compilation on OS X
#endif

    // glfw window creation
    // --------------------
	monitors = glfwGetPrimaryMonitor();
	getResolution();

    GLFWwindow* window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "Practica 3 20231", NULL, NULL);
    if (window == NULL)
    {
        std::cout << "Failed to create GLFW window" << std::endl;
        glfwTerminate();
        return -1;
    }
	glfwSetWindowPos(window, 0, 30);
    glfwMakeContextCurrent(window);
    glfwSetFramebufferSizeCallback(window, resize);

	glewInit();


	//Mis funciones
	//Datos a utilizar
	myData();
	glEnable(GL_DEPTH_TEST);

	//Prepare to draw the scene with Projections
	//Shader myShader("shaders/shader.vs", "shaders/shader.fs");
	Shader myShader("shaders/shader_projection.vs", "shaders/shader_projection.fs");

	myShader.use();
	// create transformations and Projection
	//La matriz de modelo permite realizar las 3 tranformaciones de manera individual a cada modelo
	glm::mat4 modelOp = glm::mat4(1.0f);		// initialize Matrix, Use this matrix for individual models
	//Matriz de vista,permite realizar las 3 tranformaciones de manera global (a todos los modelos) 
	glm::mat4 viewOp = glm::mat4(1.0f);			//Use this matrix for ALL models
	glm::mat4 projectionOp = glm::mat4(1.0f);	//This matrix is for Projection

	//Use "projection" in order to change how we see the information

	//Comando para la proyección en perpectiva
	projectionOp = glm::perspective(glm::radians(45.0f), (float)SCR_WIDTH / (float)SCR_HEIGHT, 0.1f, 100.0f); //
								//	glm::radians(45.0f), (float)SCR_WIDTH / (float)SCR_HEIGHT, Zmin, Zmax);
																											  // 
																											  //

	
	//projectionOp = glm::ortho(-5.0f, 5.0f, -3.0f, 3.0f, 0.1f, 10.0f); //Comando para la proyeción ortogonal
																	  //glm::ortho(Xizq, Xder,  Yinf, Ysup, Zmin, Zmax)
																	  //Los valores de Z son el campo de vision de profundidad, se recomienda que sean valores positivos
																	  //Con estos 6 valores del volumen de vista

    // render loop
    // While the windows is not closed
    while (!glfwWindowShouldClose(window))
    {
        // input
        // -----
        my_input(window);

        // render
        // Backgound color
        glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		//Mi función de dibujo
		/*******************************************/
		//Use "view" in order to affect all models
		
		
		//viewOp = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));//glm::mat4(1.0f) esto significa el origen del sistema y es la matriz unitaria
																			  //glm::vec3(Mov X, Mov Y, Mov Z) todo en unidades del sistema de referencia
																			  // Modificamos los valores y le podemos asignar una variables a cada movimiento
		
		
		viewOp = glm::translate(glm::mat4(1.0f), glm::vec3(MovX, MovY, MovZ));
		// pass them to the shaders
		myShader.setMat4("model", modelOp);
		myShader.setMat4("view", viewOp);
		// note: currently we set the projection matrix each frame, but since the projection matrix rarely changes it's often best practice to set it outside the main loop only once.
		myShader.setMat4("projection", projectionOp);
		

		glBindVertexArray(VAO[1]);	//Enable data array [1]
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[1]); //Only if we are going to work with index
		/*
		modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));
		myShader.setMat4("model", modelOp);
		//Aqui dibuja la letra C con ArregloLuis
		
		//Comentamos para inicar desde 0
		
		glDrawArrays(GL_LINE_LOOP, 0, 8); //My C
		//glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, (void*)(0 * sizeof(float)));	//to Draw using index


		//-------------------Second figure-------------------
		//Manda a llamar a los vertices del cubo
		glBindVertexArray(VAO[0]);	//Enable data array [0]
		//Matriz de modelo del cubo
		modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));
		myShader.setMat4("model", modelOp);
		//Dibuja el cubo
		glDrawArrays(GL_TRIANGLES, 0, 36); //My Cube 1

		//-------------------3ra figura-------------------
		//modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(1.5f, 4.2f, 0.0f));//glm::translate(punto de referencia, movimiento);
		modelOp = glm::translate(modelOp, glm::vec3(0.0f, 4.2f, 0.0f)); //Ahora lo hacemos apartir de del cubo que ya se tenia
		myShader.setMat4("model", modelOp);
		glDrawArrays(GL_TRIANGLES, 0, 36); //My Cube 2
		

		
		glBindVertexArray(VAO[0]);
		*/

		//Para dibujar el emoji
		int x = 6,//Valor del eje X
			j = 0,//Valor del eje Y
			lim = 13, //Limite que se utliza hasta donde llegara en el eje X, depende del valor de J 
			i = x;//Variable que ayudara a recorrer el eje X
		glBindVertexArray(VAO[0]);
		//Dibuja el punto de origen elegido
		modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));
		myShader.setMat4("model", modelOp);
		myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f));
		glDrawArrays(GL_TRIANGLES, 0, 36);

		//Posiciona el cubo en lo primero que pintara
		modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(x-1, j, 0.0f));//Se inicia en x-1, ya que al inicio del for se recorrera hacia la derecha una posicion 
																		   //y tomara el valor de x en ese entonces
		myShader.setMat4("model", modelOp);

		for (i; i <lim; i++) {
			modelOp = glm::translate(modelOp, glm::vec3(1.0f, 0.0f, 0.0f));//Recorre el cubo una unidad a la derecha
			myShader.setMat4("model", modelOp);
			myShader.setVec3("aColor", glm::vec3(1.0f, 1.0f, 0.0f)); //Manda el color amarillo al shader
			//Todo lo que no este dentro de los siguientes rangos lo rellenara de cubos de color amarrillo

			//Dibuja la sonrisa
			//Parte de abajo
			
			if(i==x||i==lim-1||j==0||j==18)
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f));//Manda el color negro al shader
			
			if ((7 <= i && i <= 11) && (j == 3))
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f)); //Manda el color negro al shader
			
			//Puntos de arriba
			if (j == 4 && (i == 6 || i == 12))
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f)); //Manda el color negro al shader
			
			//Lentes
			if (j==11)
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f)); //Manda el color negro al shader
			
			if (j == 10 && (2 <= i && i <= 16)) {
				if(i==6||i==7||i==13||i==14)
					myShader.setVec3("aColor", glm::vec3(1.0f, 1.0f, 1.0f));//Parte bllanca de los lentes
				else
					myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f)); //Manda el color negro al shader
			}
			
			if (j == 9 && ( (2 <= i && i <= 8) || (10 <= i && i <= 16) ) ){
				if (i == 6 || i == 13)
					myShader.setVec3("aColor", glm::vec3(1.0f, 1.0f, 1.0f));//Parte bllanca de los lentes
				else
					myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f)); //Manda el color negro al shader
			}

			if (j == 8 && ((3 <= i && i <= 7) || (11 <= i && i <= 15)))
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f));//Manda el color negro al shader
			
			if (j == 7 && ((4 <= i && i <= 6) || (12 <= i && i <= 14)))
				myShader.setVec3("aColor", glm::vec3(0.0f, 0.0f, 0.0f));//Manda el color negro al shader

			//Dibuja el cubo
			glDrawArrays(GL_TRIANGLES, 0, 36);

			//Cambia el valor de X donde se iniciara, el limite de hasta donde se dibura el cubo
			//Sube una posicion en el eje Y y reinicia el contador del for al nuevo valor de X
			if (i==lim-1 && j<18) {
				if (x > 0 && j<13) {
					x --;
					lim++;
				}
				if (x < 7 && j >= 12) {
					x++;
					lim--;
				}
				j++;
				i = x-1;
				modelOp = glm::translate(glm::mat4(1.0f), glm::vec3(x-1, j, 0.0f));//Realiza el traslado del cubo a x-1 y j respecto al origen
				myShader.setMat4("model", modelOp);
			}
		}


		glBindVertexArray(0);
		/*****************************************************************/
        // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
        // -------------------------------------------------------------------------------
        glfwSwapBuffers(window);
        glfwPollEvents();
    }

    // glfw: terminate, clearing all previously allocated GLFW resources.
    // ------------------------------------------------------------------
    glfwTerminate();
    return 0;
}

// process all input: query GLFW whether relevant keys are pressed/released this frame and react accordingly
// ---------------------------------------------------------------------------------------------------------
//
void my_input(GLFWwindow *window)
{
	//Condicion para cerrar la ventana con la tecla Esc
    if(glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)  //GLFW_RELEASE
        glfwSetWindowShouldClose(window, true);
	//Condiciones para que se detecte que se preciono una tecla y se realice la traslación
	//A		hacia la Izq
	if (glfwGetKey(window, GLFW_KEY_A) == GLFW_PRESS)
		MovX -= 0.1f;
	//D		hacia la Der
	if (glfwGetKey(window, GLFW_KEY_D) == GLFW_PRESS)
		MovX += 0.1f;
	//HOME		hacia arriba
	if (glfwGetKey(window, GLFW_KEY_HOME) == GLFW_PRESS)
		MovY += 0.1f;
	//END		hacia abajo
	if (glfwGetKey(window, GLFW_KEY_END) == GLFW_PRESS)
		MovY -= 0.1f;
	//Para profundidad
	//W			hacia dentro
	if (glfwGetKey(window, GLFW_KEY_W) == GLFW_PRESS)
		MovZ += 0.1f;
	//S		hacia afuera
	if (glfwGetKey(window, GLFW_KEY_S) == GLFW_PRESS)
		MovZ -= 0.1f;
}

// glfw: whenever the window size changed (by OS or user resize) this callback function executes
// ---------------------------------------------------------------------------------------------
void resize(GLFWwindow* window, int width, int height)
{
    // Set the Viewport to the size of the created window
    glViewport(0, 0, width, height);
}