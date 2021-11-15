const express = require('express');
const app = express();
const port = 3000;
const routerApi=require('./routes')
app.use(express.json());

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/route-new', (req, res) => {
    res.send('Hola soy una nueva ruta o endpoint');
});

app.get('/info',(req,res)=>{
    res.json({
        "dependencies": {
            "express": "^4.17.1"
          }
    })
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})

routerApi(app);