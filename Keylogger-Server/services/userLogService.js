const getConnection = require('../libs/postgres');
const pool = require('../libs/postgres.pool');

class UserLogService {
  constructor() {
    this.pool = pool;
    this.pool.on('error', (err) => console.error(err));
  }

  async create(data) {
    return data;
  }

  async find() {
    const client = await getConnection();
    const rta = await client.query('SELECT * FROM public.victima');
    return rta;
  }
  async postLog(victima_id, log) {
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var dateTime = date + ' ' + time;
    const client = await getConnection();
    await client.query('INSERT INTO log (victima_id,log,log_date) VALUES ($1,$2,$3)', [victima_id,log,dateTime]);
  }



  async  getVictimList(){
    const client=await getConnection();
    const rta=await client.query();
  }

  async getLogList(){
    const client=await getConnection();
    const rta= await client.query('SELECT * FROM public.log');
  }


  async findOne(id) {
    return { id };
  }

  async update(id, changes) {
    return {
      id,
      changes,
    };
  }

  async delete(id) {
    return { id };
  }
}
//exportar el servicio para log del usuario
module.exports = UserLogService;