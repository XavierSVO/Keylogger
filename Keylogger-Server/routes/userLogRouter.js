
const express = require('express');
const router=express.Router();
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

router.get('/:id', (req, res) => {
    const { id } = req.params;
    res.json({
        id,
        name: 'iPhone X3',
        price: 32000,
    });
});

router.get('/categories/:categoryId/products/:productId', (req, res) => {
    const { categoryId, productId } = req.params;
    res.json({
        categoryId,
        productId
    });
});

module.exports=router;