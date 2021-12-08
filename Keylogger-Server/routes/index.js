// Importar el Router de Usuario
const userLogRouter=require('./userLogRouter');
//Importar Express
const express=require('express');
//Funcion para usar las direcciones del router de eventos de teclado
function routerApi(app){
    // crear instancia del express router
    const router=express.Router();
    //agregar api al  sufijo del router 
    app.use('/api',router);
    // declarar que se  usa el router de eventos de teclado
    router.use('/userLog',userLogRouter);
}
// Exportar la funcion de router Api
module.exports=routerApi;