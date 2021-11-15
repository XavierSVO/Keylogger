const express=require('express');
const bodyParser=(require('body-parser'));
const router=express.Router();
var app=express();
app.use(bodyParser.json());
app.use(router);
// app.use('/',function(request,response){
//     response.send('Hola');
// })
router.get('/',function(req,res){
    res.send('Hola desde get');
})
router.post('/',function(req,res){
    console.log(req.query);
    res.send('Hola desde post');

})
app.listen(3000);
console.log('Aplicacion en el puerto 3000')