using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkDepratmentMisson.Models;

namespace WorkDepratmentMisson.Controllers.api
{
    public class WorkerController : ApiController
    {
        
        DeprtmentDB DepartmentDB = new DeprtmentDB();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DepartmentDB.Workers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);  
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public async Task <IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok( await DepartmentDB.Workers.FindAsync(id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public async Task <IHttpActionResult> Post([FromBody] Worker value)
        {
            try
            {
                DepartmentDB.Workers.Add(value);
                await DepartmentDB.SaveChangesAsync();
                return Ok(DepartmentDB.Workers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

       
        public async Task <IHttpActionResult> Put(int id, [FromBody] Worker value)
        {
            try
            {
                Worker someCar = await DepartmentDB.Workers.FindAsync(id);
                someCar.Id = value.Id;
                someCar.FisrtName = value.FisrtName;
                someCar.LastName = value.LastName;
                someCar.Age = value.Age;
                await DepartmentDB.SaveChangesAsync();  
                return Ok(DepartmentDB.Workers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        public async Task <IHttpActionResult> Delete(int id)
        {
            try
            {
                DepartmentDB.Workers.Remove(await DepartmentDB.Workers.FindAsync( id));
                await DepartmentDB.SaveChangesAsync();
                return Ok(DepartmentDB.Workers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }

        }
    }
}
