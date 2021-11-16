//importar la libreria pg para conectarse con postgres
const {Client}=require('pg');
//crear la funciona asincrona para obtener la conexion
async function getConnection(){
    //crear objeto de conexion con los datos de la conexion
    const client=new Client({
        user: 'keylogger',
        host: 'localhost',
        database: 'keylogger',
        password: 'keylogger_admin',
        port: 5432,
    })
    await client.connect();
    return client;
}
//exportar el modulo de conexion
module.exports=getConnection;
