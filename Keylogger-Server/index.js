//importar la libreria de express
const express = require('express');
// crear la instancia de express
const app = express();
//declarar el  puerto  que usuara el  programa
const port = 3000;
//importar la libreria path
const path = require('path');
//importar la libreria de rutas
const routerApi=require('./routes')
//declarar que en nuestra app usaremos archivos en formato json
app.use(express.json());
// declarar lo que se realizara cuando se ingrese a la ruta vacia
app.get('/', (req, res) => {
// enviar al usuario a una pagina web
  res.sendFile(path.join(__dirname+'/index.html'));
})
// funcion que captura lo que ocurre con el puerto
app.listen(port, () => {
  //imprimir por la consola el puerto  que esta usando la aplicacion
  console.log(`Example app listening at http://localhost:${port}`)
})
//Declarar  en el router la app de  express  
routerApi(app);