/*---------------------------------------------------------*/
/* ----------------   Práctica 2 --------------------------*/
/*-----------------    2023-1   ---------------------------*/
/*------------- Arriaga Mejía José Carlos ---------------*/
#include <glew.h>
#include <glfw3.h>
#include <iostream>

void resize(GLFWwindow* window, int width, int height);
void my_input(GLFWwindow *window);

// settings
// Window size
int SCR_WIDTH = 800;
int SCR_HEIGHT = 600;

GLFWmonitor *monitors;
GLuint VBO[2], VAO[2], EBO[2];
GLuint shaderProgramYellow, shaderProgramColor;
//layout (orden) entrada/salida tam_vector nombre;
//layout (location = 0) in vec3 aPos;		
static const char* myVertexShader = "										\n\
#version 330 core															\n\
																			\n\
layout (location = 0) in vec3 aPos;											\n\
																			\n\
void main()																	\n\
{																			\n\
    gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);						\n\
}";

static const char* myVertexShaderColor = "									\n\
#version 330 core															\n\
																			\n\
layout (location = 0) in vec3 aPos;											\n\
layout (location = 1) in vec3 aColor;										\n\
out vec3 ourColor;															\n\
void main()																	\n\
{																			\n\
    gl_Position = vec4(aPos, 1.0);											\n\
	ourColor = aColor;														\n\
}";

// Fragment Shader
static const char* myFragmentShaderYellow = "									\n\
#version 330																\n\
																			\n\
out vec3 finalColor;														\n\
																			\n\
void main()																	\n\
{																			\n\
    finalColor = vec3(1.0f, 1.0f, 0.0f);									\n\
}";

static const char* myFragmentShaderColor = "								\n\
#version 330 core															\n\
out vec4 FragColor;															\n\
in vec3 ourColor;															\n\
																			\n\
void main()																	\n\
{																			\n\
	FragColor = vec4(ourColor, 1.0f);										\n\
}";

void myData(void);
void setupShaders(void);
void display(void);
void getResolution(void);


void getResolution()
{
	const GLFWvidmode * mode = glfwGetVideoMode(glfwGetPrimaryMonitor());

	SCR_WIDTH = mode->width;
	SCR_HEIGHT = (mode->height) - 80;
}

void myData()
{
	float vertices[] = 
	{
		//Letra C
		// positions			//Color
		-0.5f,  0.5f, 0.0f,		1.0f, 0.0f, 0.0f,// 0 ROJO
		0.0f, 0.5f, 0.0f,		1.0f, 1.0f, 0.0f,// 1 AMARILLO
		0.0f, 0.4f, 0.0f,		1.0f, 1.0f, 1.0f,// 2 BLANCO
		-0.4f, 0.4f, 0.0f,		0.0f, 1.0f, 1.0f,// 3 CIAN
		-0.4f, 0.1f, 0.0f,		0.0f, 0.0f, 1.0f,// 4 AZUL
		0.0f, 0.1f, 0.0f,		1.0f, 0.0f, 1.0f,// 5 MAGENTA
		0.0f, 0.0f, 0.0f,		0.6f, 1.0f, 0.3f,// 6
		-0.5f, 0.0f, 0.0f,		0.0f, 1.0f, 0.0f,// 7 VERDE

		//Para rellenar la C
		/*-0.5f,  0.5f, 0.0f,		1.0f, 0.0f, 0.0f,// 0 ROJO
		0.0f, 0.5f, 0.0f,		1.0f, 1.0f, 0.0f,// 1 AMARILLO
		-0.4f, 0.4f, 0.0f,		0.0f, 1.0f, 1.0f,// 3 CIAN
		
		0.0f, 0.5f, 0.0f,		1.0f, 1.0f, 0.0f,// 1 AMARILLO
		0.0f, 0.4f, 0.0f,		1.0f, 1.0f, 1.0f,// 2 BLANCO
		-0.4f, 0.4f, 0.0f,		0.0f, 1.0f, 1.0f,// 3 CIAN
		
		-0.5f,  0.5f, 0.0f,		1.0f, 0.0f, 0.0f,// 0 ROJO
		-0.4f, 0.4f, 0.0f,		0.0f, 1.0f, 1.0f,// 3 CIAN
		-0.5f, 0.0f, 0.0f,		0.0f, 1.0f, 0.0f,// 7 VERDE

		-0.4f, 0.4f, 0.0f,		0.0f, 1.0f, 1.0f,// 3 CIAN
		-0.4f, 0.1f, 0.0f,		0.0f, 0.0f, 1.0f,// 4 AZUL
		-0.5f, 0.0f, 0.0f,		0.0f, 1.0f, 0.0f,// 7 VERDE

		-0.4f, 0.1f, 0.0f,		0.0f, 0.0f, 1.0f,// 4 AZUL
		0.0f, 0.0f, 0.0f,		0.6f, 1.0f, 0.3f,// 6
		-0.5f, 0.0f, 0.0f,		0.0f, 1.0f, 0.0f,// 7 VERDE

		-0.4f, 0.1f, 0.0f,		0.0f, 0.0f, 1.0f,// 4 AZUL
		0.0f, 0.1f, 0.0f,		1.0f, 0.0f, 1.0f,// 5 MAGENTA
		0.0f, 0.0f, 0.0f,		0.6f, 1.0f, 0.3f,// 6
		*/

		//Estrella
		0.5f, -0.5f, 0.0f,		1.0f, 0.0f, 0.0f,// 8 ROJO
		0.8f, -0.4f, 0.0f,		1.0f, 1.0f, 0.0f,// 9 AMARILLO
		0.6f, -0.4f, 0.0f,		1.0f, 1.0f, 1.0f,// 10 BLANCO
		0.5f, -0.2f, 0.0f,		0.0f, 1.0f, 1.0f,// 11 CIAN
		0.4f, -0.4f, 0.0f,		0.0f, 0.0f, 1.0f,// 12 AZUL
		0.2f, -0.4f, 0.0f,		1.0f, 0.0f, 1.0f,// 13 MAGENTA
		0.3f, -0.5f, 0.0f,		0.6f, 1.0f, 0.3f,// 14
		0.3f, -0.7f, 0.0f,		0.0f, 1.0f, 0.0f,// 15 VERDE
		0.5f, -0.6f, 0.0f,		1.0f, 0.0f, 1.0f,// 16 MAGENTA
		0.7f, -0.7f, 0.0f,		0.6f, 1.0f, 0.3f,// 17
		0.7f, -0.5f, 0.0f,		0.0f, 1.0f, 0.0f,// 18 VERDE

		//Estrella Sup Der
		0.5f, 0.5f, 0.0f,		1.0f, 1.0f, 1.0f,// 19 Negro		A
		0.5f, 1.0f, 0.0f,		1.0f, 1.0f, 1.0f,// 20 Blanco		C
		0.614f, 0.648f, 0.0f,	0.0f, 0.0f, 0.0f,// 21 Negro		J
		0.97f, 0.648f, 0.0f,	1.0f, 1.0f, 1.0f,// 22 Blanco		E
		0.682f, 0.436f, 0.0f,	0.0f, 0.0f, 0.0f,// 23 Negro		K
		0.793f, 0.095f, 0.0f,	1.0f, 1.0f, 1.0f,// 24 Blanco		G
		0.5f, 0.305f, 0.0f,		0.0f, 0.0f, 0.0f,// 25 Negro		L
		0.206f, 0.095f, 0.0f,	1.0f, 1.0f, 1.0f,// 26 Blanco		H
		0.317f, 0.436f, 0.0f,	0.0f, 0.0f, 0.0f,// 27 Negro		M
		0.03f, 0.648f, 0.0f,	1.0f, 1.0f, 1.0f,// 28 Blanco		F
		0.3861f, 0.648f, 0.0f,	0.0f, 0.0f, 0.0f,// 29 Negro		I

		//Letra J
		-0.4f, -0.4f, 0.0f,		0.0f, 0.0f, 0.0f,// 30 Negro		Pivote 1
		-0.2f, -0.4f, 0.0f,		0.0f, 0.0f, 1.0f,// 31 Rojo	
		-0.2f, -0.2f, 0.0f,		0.0f, 0.0f, 1.0f,// 32 Rojo	
		-0.8f, -0.2f, 0.0f,		0.0f, 0.0f, 1.0f,// 33 Rojo
		-0.8f, -0.4f, 0.0f,		0.0f, 0.0f, 1.0f,// 34 Rojo
		-0.6f, -0.4f, 0.0f,		0.0f, 0.0f, 1.0f,// 35 Azul	
		-0.6f, -0.7f, 0.0f,		0.0f, 0.0f, 0.0f,// 36 Negro		Pivote 2
		-0.8f, -0.7f, 0.0f,		0.0f, 0.0f, 1.0f,// 37 Azul		
		-0.8f, -0.9f, 0.0f,		0.0f, 0.0f, 1.0f,// 38 Azul		
		-0.4f, -0.9f, 0.0f,		0.0f, 0.0f, 1.0f,// 39 Azul		
	};

	//Genera la agrupacion de indices para evitar repetir los indices y esto se manda al elements linea 268 aprox
	unsigned int indices[] =
	{
		//Con GL_TRIANGLE_FAN
		
		3,2,1,0,7,4, //El 3 es el pivote
		4,7,6,5, //El 4 como pivote
		// Se tendiran que llamarlo dos veces al gldrawselement uno que empieza en el 0 y dibuja 6 elementos, el otro de 6 y dibuja 4
		
		//Con GL_TRIANGLES
		/*
		0,1,3,
		1,2,3,
		0,3,7,
		3,4,7,
		4,6,7,
		4,5,6,
		*/

		//Indices estrella Con triangle fan
		8,9,10,11,12,13,14,15,16,17,18,9,

		//Indices estrella sup der con triangle fan
		19,20,21,22,23,24,25,26,27,28,29,20,

		//Letra J
		30,31,32,33,34,
		36,37,38,39,30,35,
	};

	glGenVertexArrays(2, VAO);
	glGenBuffers(2, VBO);
	glGenBuffers(2, EBO);



	glBindVertexArray(VAO[0]);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[0]);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
	//Aqui se explica como esta formado el vector de vertices
	// position attribute
/*	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, (void*)0);
	glEnableVertexAttribArray(0);
*/
	//Cambiamos el 0 a 6 * sizeof(float)
	//glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float)->Cant de lecturas para encontrar el primer valor del mismo tipo de atributo, (void*)0->Primer valor del atributo en este caso, el indice 0 de la fila vector); 
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)0);
	glEnableVertexAttribArray(0);

	// color attribute
	//glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)(3->Primer valor del atributo * sizeof(float)));Es decir, en el indice 3 de la fila vector
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)(3 * sizeof(float)));
	glEnableVertexAttribArray(1);

	//Para trabajar con indices (Element Buffer Object)
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[0]);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

	glBindBuffer(GL_ARRAY_BUFFER, 0);

	glBindVertexArray(0);

}

void setupShaders()
{	//Creacion de un contenedor de shader de vertices 
	unsigned int vertexShader = glCreateShader(GL_VERTEX_SHADER);
	//(nomb_contenedor, # de contenedores, codigo creado (linea 22 en este caso), nodijoxd )
	glShaderSource(vertexShader, 1, &myVertexShader, NULL);
	//Compilacion del shader por el hardware gráfico
	glCompileShader(vertexShader);
	//Lo mismo con los demás

	unsigned int vertexShaderColor = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vertexShaderColor, 1, &myVertexShaderColor, NULL);
	glCompileShader(vertexShaderColor);

	unsigned int fragmentShaderYellow = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fragmentShaderYellow, 1, &myFragmentShaderYellow, NULL);
	glCompileShader(fragmentShaderYellow);

	unsigned int fragmentShaderColor = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fragmentShaderColor, 1, &myFragmentShaderColor, NULL);
	glCompileShader(fragmentShaderColor);


	//Crear el Programa que combina Geometría con Color
	shaderProgramYellow = glCreateProgram();
	glAttachShader(shaderProgramYellow, vertexShader);
	glAttachShader(shaderProgramYellow, fragmentShaderYellow);
	glLinkProgram(shaderProgramYellow);
	//shaderProgramYellow une los shaders vertexShader y fragmentShaderYellow

	shaderProgramColor = glCreateProgram();
	glAttachShader(shaderProgramColor, vertexShaderColor);
	glAttachShader(shaderProgramColor, fragmentShaderColor);
	glLinkProgram(shaderProgramColor);
	//Check for errors 

	//ya con el Programa, el Shader no es necesario
	glDeleteShader(vertexShader);
	glDeleteShader(vertexShaderColor);
	glDeleteShader(fragmentShaderYellow);
	glDeleteShader(fragmentShaderColor);

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

    GLFWwindow* window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "Practica 2", NULL, NULL);
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


	//My Functions
	//Setup Data to use
	myData();
	//To Setup Shaders
	setupShaders();
    
    // render loop
    // While the windows is not closed
    while (!glfwWindowShouldClose(window))
    {
        // input
        // -----
        my_input(window);

        // render
        // Background color
        glClearColor(0.3f, 0.3f, 0.3f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

		//Display Section
		//Manda a llamar a los programa que une a los shaders
	//	glUseProgram(shaderProgramYellow);
		glUseProgram(shaderProgramColor);

		glBindVertexArray(VAO[0]);
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[0]);

		glPointSize(5.0);
		//Letra C
		glDrawElements(GL_TRIANGLE_FAN, 6, GL_UNSIGNED_INT, 0);
		glDrawElements(GL_TRIANGLE_FAN, 4, GL_UNSIGNED_INT, (void*)(6*sizeof(float)));
		//Estrella 
		glDrawElements(GL_TRIANGLE_FAN, 12, GL_UNSIGNED_INT, (void*)(10 * sizeof(float)));
		//Estrella Sup Der
		glDrawElements(GL_TRIANGLE_FAN, 12, GL_UNSIGNED_INT, (void*)(22 * sizeof(float)));
		//Letra J
		glDrawElements(GL_TRIANGLE_FAN, 5, GL_UNSIGNED_INT, (void*)(34 * sizeof(float)));
		glDrawElements(GL_TRIANGLE_FAN, 6, GL_UNSIGNED_INT, (void*)(39 * sizeof(float)));
	
	//	glDrawElements(GL_TRIANGLES, 18, GL_UNSIGNED_INT, 0);
		//Comentamos la linea de abajo y descomentamos la de arriba
		// //glDrawArrays(GL_TRIANGLES, 0, 18); //Rellena la C, los distintos vertices
		
		//glDrawArrays(GL_LINE_LOOP, 0, 8); //Dibula las lineas de la C en colores 


		glBindVertexArray(0);
		glUseProgram(0);

		//End of Display Section

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
void my_input(GLFWwindow *window)
{
    if(glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)  //GLFW_RELEASE
        glfwSetWindowShouldClose(window, true);
}

// glfw: whenever the window size changed (by OS or user resize) this callback function executes
// ---------------------------------------------------------------------------------------------
void resize(GLFWwindow* window, int width, int height)
{
    // Set the Viewport to the size of the created window
    glViewport(0, 0, width, height);
}