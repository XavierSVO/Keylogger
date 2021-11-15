const userLogRouter=require('./userLogRouter');
const express=require('express');
function routerApi(app){
    const router=express.Router();
    app.use('/api',router);
    router.use('/userLog',userLogRouter);
}
module.exports=routerApi;