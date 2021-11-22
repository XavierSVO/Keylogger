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

router.post('/',(req,res)=>{
    const body=req.body;
    res.json({
        message:'log created',
        data:body
    });
})


module.exports=router;