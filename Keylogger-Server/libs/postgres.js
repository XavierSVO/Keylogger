const {Client}=require('pg');
async function getConnection(){
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
module.exports=getConnection;
